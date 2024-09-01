using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Security.Policy;
using System.Collections;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.IdentityModel.Tokens;

namespace Lab8
{
    public partial class MainWindow : Window
    {
        private SqlConnection? sqlConnection = null;
        private int selectedIDEvents = 0;
        private int selectedIDUsers = 0;
        private int selectedIDPurchases = 0;
        private bool upEvents = true;
        private bool upUsers = true;
        private bool upPurchases = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetConnection()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение к бд установлено");

                // Проверка на существование процедуры BuyTickets
                string checkProcedureQuery = "SELECT COUNT(*) FROM sys.procedures WHERE name = 'BuyTickets'";
                using (SqlCommand checkCommand = new SqlCommand(checkProcedureQuery, sqlConnection))
                {
                    int procedureExists = (int)checkCommand.ExecuteScalar();

                    // Если процедура не существует, создаем ее
                    if (procedureExists == 0)
                    {
                        string createBuyTicketsProcedure = @"
                        CREATE PROCEDURE BuyTickets
                            @EventID INT,
                            @UserID INT,
                            @TicketAmount INT
                        AS
                        BEGIN
                            SET NOCOUNT ON; 

                            BEGIN TRANSACTION;
                            
                            BEGIN TRY
                                IF (SELECT TicketAmount FROM Events WHERE EventID = @EventID) >= @TicketAmount
                                BEGIN
                                    UPDATE Events SET TicketAmount = TicketAmount - @TicketAmount WHERE EventID = @EventID;
                                    INSERT INTO Purchases (EventID, UserID, TicketsAmount, PurchaseDate, PurchasePrice)
                                    VALUES (@EventID, @UserID, @TicketAmount, GETDATE(), @TicketAmount * (SELECT TicketPrice FROM Events WHERE EventID = @EventID));
                                    COMMIT TRANSACTION;
                                    SELECT 'Покупка билетов завершена!' AS Message;
                                END
                                ELSE
                                BEGIN
                                    ROLLBACK TRANSACTION;
                                    SELECT 'Недостаточно билетов для выбранного мероприятия.' AS Message;
                                END
                            END TRY
                            BEGIN CATCH
                                IF @@TRANCOUNT > 0
                                    ROLLBACK TRANSACTION;
                                THROW;
                            END CATCH
                        END;
                    ";

                        using (SqlCommand createCommand = new SqlCommand(createBuyTicketsProcedure, sqlConnection))
                        {
                            createCommand.ExecuteNonQuery();
                            MessageBox.Show("Процедура BuyTickets успешно создана!");
                        }
                    }
                }
            }
            else if (sqlConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("Подключение к бд не установлено");
                try
                {
                    sqlConnection = new SqlConnection();
                    string createDatabaseQuery = "CREATE DATABASE YourDatabaseName";
                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string useDatabaseQuery = "USE YourDatabaseName";
                    using (SqlCommand command = new SqlCommand(useDatabaseQuery, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string createEventsTableQuery = @"
                        CREATE TABLE [dbo].[Events] (
                            [EventID]       INT            IDENTITY (1, 1) NOT NULL,
                            [EventName]     NVARCHAR (30)  NOT NULL,
                            [EventData]     DATETIME       NOT NULL,
                            [EventLocation] NVARCHAR (30)  NOT NULL,
                            [TicketPrice]   INT            NOT NULL,
                            [TicketAmount]  INT            NOT NULL,
                            [EventImage]    NVARCHAR (MAX) NOT NULL,
                            PRIMARY KEY CLUSTERED ([EventID] ASC),
                            UNIQUE NONCLUSTERED ([EventName] ASC),
                            CHECK ([EventData]>getdate()),
                            CHECK ([TicketPrice]>=(5)),
                            CHECK ([TicketAmount]>=(0))
                        );";

                    string createPurchasesTableQuery = @"
                        CREATE TABLE [dbo].[Purchases] (
                            [PurchasesID]   INT      IDENTITY (1, 1) NOT NULL,
                            [EventID]       INT      NOT NULL,
                            [UserID]        INT      NOT NULL,
                            [TicketsAmount] INT      NOT NULL,
                            [PurchaseDate]  DATETIME NOT NULL,
                            [PurchasePrice] INT      NOT NULL,
                            PRIMARY KEY CLUSTERED ([PurchasesID] ASC),
                            FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([EventID]),
                            FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
                        );";

                    string createUsersTableQuery = @"
                        CREATE TABLE [dbo].[Users] (
                            [UserID]    INT           IDENTITY (1, 1) NOT NULL,
                            [UserName]  NVARCHAR (30) NOT NULL,
                            [UserEmail] NVARCHAR (40) NOT NULL,
                            PRIMARY KEY CLUSTERED ([UserID] ASC)
                        );";

                    string createBuyTicketsProcedure = @"
                        CREATE PROCEDURE BuyTickets
                            @EventID INT,
                            @UserID INT,
                            @TicketAmount INT
                        AS
                        BEGIN
                            SET NOCOUNT ON; -- отключаем вывод количества строк

                            BEGIN TRANSACTION;
                            
                            BEGIN TRY
                                -- Проверка наличия билетов
                                IF (SELECT TicketAmount FROM Events WHERE EventID = @EventID) >= @TicketAmount
                                BEGIN
                                    -- Обновление количества билетов
                                    UPDATE Events SET TicketAmount = TicketAmount - @TicketAmount WHERE EventID = @EventID;

                                    -- Добавление записи в Purchases
                                    INSERT INTO Purchases (EventID, UserID, TicketsAmount, PurchaseDate, PurchasePrice)
                                    VALUES (@EventID, @UserID, @TicketAmount, GETDATE(), @TicketAmount * (SELECT TicketPrice FROM Events WHERE EventID = @EventID));

                                    -- Подтверждение транзакции
                                    COMMIT TRANSACTION;

                                    -- Вывод сообщения об успешной покупке
                                    SELECT 'Покупка билетов завершена!' AS Message;
                                END
                                ELSE
                                BEGIN
                                    -- Отмена транзакции
                                    ROLLBACK TRANSACTION;

                                    -- Вывод сообщения об ошибке
                                    SELECT 'Недостаточно билетов для выбранного мероприятия.' AS Message;
                                END
                            END TRY
                            BEGIN CATCH
                                -- Отмена транзакции в случае ошибки
                                IF @@TRANCOUNT > 0
                                    ROLLBACK TRANSACTION;

                                -- Вывод сообщения об ошибке
                                THROW;
                            END CATCH
                        END;
                    ";

                    using (SqlCommand command = new SqlCommand(createEventsTableQuery, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(createUsersTableQuery, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(createPurchasesTableQuery, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(createBuyTicketsProcedure, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetConnection();
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;

            update_btn_user.IsEnabled = false;
            delete_btn_user.IsEnabled = false;
            update_btn_purchases.IsEnabled = false;
            delete_btn_purchases.IsEnabled = false;
            updateDataGrid(0);
            updateDataGrid(1);
            updateDataGrid(2);
            CompletionCombobox();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            sqlConnection?.Close();
        }

        private void select_photo_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                    event_image.Source = bitmapImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                }
            }
        }

        private void SetImage(string imagePath)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                event_image.Source = bitmapImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
            }
        }

        // обновление таблицы
        private void updateDataGrid(int n)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
                {
                    connection.Open();
                    string sortOrder = "";
                    SqlCommand? command = null; ;
                    if (n == 0)
                    {
                        sortOrder = upEvents ? "DESC" : "ASC";
                        string? selectedItemText = (SortCombobox.SelectedItem as ComboBoxItem)?.Content.ToString();
                        if (selectedItemText == "EventDate") selectedItemText = "EventData";
                        command = new($"SELECT * FROM Events ORDER BY [{selectedItemText}] {sortOrder}", connection);
                        CompletionCombobox();
                    }
                    else if (n == 1)
                    {
                        sortOrder = upUsers ? "DESC" : "ASC";
                        string? selectedItemText = (SortCombobox_user.SelectedItem as ComboBoxItem)?.Content.ToString();
                        command = new($"SELECT * FROM Users ORDER BY [{selectedItemText}] {sortOrder}", connection);
                        CompletionCombobox();
                    }
                    else if (n == 2)
                    {
                        sortOrder = upPurchases ? "DESC" : "ASC";
                        string? selectedItemText = (SortCombobox_purchases.SelectedItem as ComboBoxItem)?.Content.ToString();
                        command = new($"SELECT * FROM Purchases ORDER BY [{selectedItemText}] {sortOrder}", connection);
                    }
                    SqlDataReader? dataReader = command?.ExecuteReader();
                    DataTable dataTable = new();
                    dataTable.Load(dataReader);
                    if (n == 0)
                    {
                        myDataGridEvents.ItemsSource = dataTable.DefaultView;
                    }
                    else if (n == 1)
                    {
                        myDataGridUsers.ItemsSource = dataTable.DefaultView;
                    }
                    else if (n == 2)
                    {
                        myDataGridPurchases.ItemsSource = dataTable.DefaultView;
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка при загрузке данных в таблицу " + ex.Message + " " + ex.StackTrace);
            }
        }

        // добавить запись
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "";
                if (sender is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == "add_btn")
                    {
                        sql = "INSERT INTO [Events] (EventName, EventData, EventLocation, TicketPrice, TicketAmount, EventImage) VALUES (@EventName, @EventData, @EventLocation, @TicketPrice, @TicketAmount, @EventImage)";
                        AUD(sql, 0, 0);
                    }
                    else if (frameworkElement.Name == "add_btn_user")
                    {
                        sql = "INSERT INTO [Users] (UserName, UserEmail) VALUES (@UserName, @UserEmail)";
                        AUD(sql, 0, 1);
                    }
                    else if (frameworkElement.Name == "add_btn_purchases")
                    {
                        sql = "INSERT INTO [Purchases] (EventID, UserID, TicketsAmount, PurchaseDate, PurchasePrice) VALUES (@EventID, @UserID, @TicketsAmount, @PurchaseDate, @PurchasePrice)";
                        AUD(sql, 0, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных в таблицу " + ex.Message + " " + ex.StackTrace);
            }
        }

        // обновить запись
        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "update_btn")
                {
                    sql = $"UPDATE [Events] SET EventName = @EventName, EventData = @EventData, EventLocation = @EventLocation, TicketPrice = @TicketPrice, TicketAmount = @TicketAmount, EventImage = @EventImage WHERE EventID = {selectedIDEvents}";
                    AUD(sql, 1, 0);
                }
                else if (frameworkElement.Name == "update_btn_user")
                {
                    sql = $"UPDATE [Users] SET UserName = @UserName, UserEmail = @UserEmail WHERE UserID = {selectedIDUsers}";
                    AUD(sql, 1, 1);
                }
                else if (frameworkElement.Name == "update_btn_purchases")
                {
                    sql = $"UPDATE [Purchases] SET EventID = @EventID, UserID = @UserID, TicketsAmount = @TicketsAmount, PurchaseDate = @PurchaseDate, PurchasePrice = @PurchasePrice WHERE PurchasesID = {selectedIDPurchases}";
                    AUD(sql, 1, 2);
                }
            }
        }

        // удалить запись
        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            string sql = "";
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "delete_btn")
                {
                    sql = $"DELETE FROM [Events] WHERE EventID = {selectedIDEvents}";
                    AUD(sql, 2, 0);
                }
                else if (frameworkElement.Name == "delete_btn_user")
                {
                    sql = $"DELETE FROM [Users] WHERE UserID = {selectedIDUsers}";
                    AUD(sql, 2, 1);
                }
                else if (frameworkElement.Name == "delete_btn_purchases")
                {
                    sql = $"DELETE FROM [Purchases] WHERE PurchasesID = {selectedIDPurchases}";
                    AUD(sql, 2, 2);
                }
            }
        }

        // сброс
        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "reset_btn")
                {
                    resetAll_Events();
                }
                else if (frameworkElement.Name == "reset_btn_user")
                {
                    resetAll_Users();
                }
                else if (frameworkElement.Name == "reset_btn_purchases")
                {
                    resetAll_Purchases();
                }
            }
        }

        private void resetAll_Events()
        {
            event_name_textbox.Text = "";
            event_date_textbox.Text = "";
            event_location_textbox.Text = "";
            event_ticket_price_textbox.Text = "";
            event_tickets_amount_textbox.Text = "";
            event_image.Source = null;
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void resetAll_Users()
        {
            user_name_textbox.Text = "";
            user_email_textbox.Text = "";
            add_btn_user.IsEnabled = true;
            update_btn_user.IsEnabled = false;
            delete_btn_user.IsEnabled = false;
        }

        private void resetAll_Purchases()
        {
            purchases_tickets_amount_textbox.Text = "";
            purchases_date_textbox.Text = "";
            purchases_price_textbox.Text = "";
            add_btn_purchases.IsEnabled = true;
            update_btn_purchases.IsEnabled = false;
            delete_btn_purchases.IsEnabled = false;
        }

        private void AUD(string sql_stmt, int state, int table)
        {
            try
            {
                string message = "";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand command = new SqlCommand(sql_stmt, connection, transaction);
                            switch (state)
                            {
                                case 0:
                                    switch (table)
                                    {
                                        case 0:
                                            command.Parameters.Add("EventName", SqlDbType.NVarChar, 30).Value = event_name_textbox.Text;
                                            command.Parameters.Add("EventData", SqlDbType.DateTime).Value = DateTime.Parse(event_date_textbox.Text);
                                            command.Parameters.Add("EventLocation", SqlDbType.NVarChar, 30).Value = event_location_textbox.Text;
                                            command.Parameters.Add("TicketPrice", SqlDbType.Int).Value = Int32.Parse(event_ticket_price_textbox.Text);
                                            command.Parameters.Add("TicketAmount", SqlDbType.Int).Value = Int32.Parse(event_tickets_amount_textbox.Text);
                                            command.Parameters.Add("EventImage", SqlDbType.NVarChar).Value = event_image.Source.ToString();
                                            add_btn.IsEnabled = false;
                                            update_btn.IsEnabled = true;
                                            delete_btn.IsEnabled = true;
                                            break;
                                        case 1:
                                            command.Parameters.Add("UserName", SqlDbType.NVarChar, 30).Value = user_name_textbox.Text;
                                            command.Parameters.Add("UserEmail", SqlDbType.NVarChar, 40).Value = user_email_textbox.Text;
                                            add_btn_user.IsEnabled = false;
                                            update_btn_user.IsEnabled = true;
                                            delete_btn_user.IsEnabled = true;
                                            break;
                                        case 2:
                                            string? selectedItemText1 = purchases_event_combobox.SelectedItem?.ToString();
                                            string? selectedItemText2 = purchases_user_combobox.SelectedItem?.ToString();
                                            command.Parameters.Add("EventID", SqlDbType.Int).Value = Int32.Parse(selectedItemText1);
                                            command.Parameters.Add("UserID", SqlDbType.Int).Value = Int32.Parse(selectedItemText2);
                                            command.Parameters.Add("TicketsAmount", SqlDbType.Int).Value = Int32.Parse(purchases_tickets_amount_textbox.Text);
                                            command.Parameters.Add("PurchaseDate", SqlDbType.DateTime).Value = DateTime.Parse(purchases_date_textbox.Text);
                                            command.Parameters.Add("PurchasePrice", SqlDbType.Int).Value = Int32.Parse(purchases_price_textbox.Text);
                                            SubtractionOfPurchasedTickets(Int32.Parse(purchases_tickets_amount_textbox.Text), Int32.Parse(selectedItemText1), connection, transaction);
                                            add_btn_purchases.IsEnabled = false;
                                            update_btn_purchases.IsEnabled = true;
                                            delete_btn_purchases.IsEnabled = true;
                                            break;
                                    }
                                    message = "Row inserted successfully";
                                    break;
                                case 1:
                                    switch (table)
                                    {
                                        case 0:
                                            command.Parameters.Add("EventName", SqlDbType.NVarChar, 30).Value = event_name_textbox.Text;
                                            command.Parameters.Add("EventData", SqlDbType.DateTime).Value = DateTime.Parse(event_date_textbox.Text);
                                            command.Parameters.Add("EventLocation", SqlDbType.NVarChar, 30).Value = event_location_textbox.Text;
                                            command.Parameters.Add("TicketPrice", SqlDbType.Int).Value = Int32.Parse(event_ticket_price_textbox.Text);
                                            command.Parameters.Add("TicketAmount", SqlDbType.Int).Value = Int32.Parse(event_tickets_amount_textbox.Text);
                                            command.Parameters.Add("EventImage", SqlDbType.NVarChar).Value = event_image.Source.ToString();
                                            resetAll_Events();
                                            break;
                                        case 1:
                                            command.Parameters.Add("UserName", SqlDbType.NVarChar, 30).Value = user_name_textbox.Text;
                                            command.Parameters.Add("UserEmail", SqlDbType.NVarChar, 40).Value = user_email_textbox.Text;
                                            resetAll_Users();
                                            break;
                                        case 2:
                                            string? selectedItemText1 = purchases_event_combobox.SelectedItem?.ToString();
                                            string? selectedItemText2 = purchases_user_combobox.SelectedItem?.ToString();
                                            UpdatePurchase(Int32.Parse(purchases_tickets_amount_textbox.Text), GetTicketCountFromPurchases(), Int32.Parse(selectedItemText1), connection, transaction);
                                            command.Parameters.Add("EventID", SqlDbType.Int).Value = Int32.Parse(selectedItemText1);
                                            command.Parameters.Add("UserID", SqlDbType.Int).Value = Int32.Parse(selectedItemText2);
                                            command.Parameters.Add("TicketsAmount", SqlDbType.Int).Value = Int32.Parse(purchases_tickets_amount_textbox.Text);
                                            command.Parameters.Add("PurchaseDate", SqlDbType.DateTime).Value = DateTime.Parse(purchases_date_textbox.Text);
                                            command.Parameters.Add("PurchasePrice", SqlDbType.Int).Value = Int32.Parse(purchases_price_textbox.Text);
                                            resetAll_Purchases();
                                            break;
                                    }
                                    message = "Row updated successfully";
                                    break;
                                case 2:
                                    switch (table)
                                    {
                                        case 0:
                                            resetAll_Events();
                                            break;
                                        case 1:
                                            resetAll_Users();
                                            break;
                                        case 2:
                                            string? selectedItemText1 = purchases_event_combobox.SelectedItem?.ToString();
                                            IncreaseOfPurchasedTickets(GetTicketCountFromPurchases(), Int32.Parse(selectedItemText1), connection, transaction);
                                            resetAll_Purchases();
                                            break;
                                    }
                                    message = "Row deleted successfully";
                                    break;
                            }
                            int n = command.ExecuteNonQuery();
                            if (n > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show(message);
                                switch (table)
                                {
                                    case 0:
                                        updateDataGrid(0);
                                        break;
                                    case 1:
                                        updateDataGrid(1);
                                        break;
                                    case 2:
                                        updateDataGrid(2);
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Ошибка при выполнении AUD " + ex.Message + " " + ex.StackTrace);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении AUD " + ex.Message + " " + ex.StackTrace);
            }
        }

        // подсчёт колва оставшихся билетов для вычисления стоимости покупки
        private int GetTicketCount(int eventId)
        {
            string query = "SELECT TicketAmount FROM Events WHERE EventID = @EventID";
            using (SqlConnection connection = new(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EventID", eventId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0;
        }

        // подсчёт цены билета для вычисления стоимости покупки
        private int GetTicketPrice(int eventId)
        {
            string query = "SELECT TicketPrice FROM Events WHERE EventID = @EventID";
            using (SqlConnection connection = new(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EventID", eventId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0;
        }

        // вычитание купленных билетов
        private void SubtractionOfPurchasedTickets(int ticketamount, int eventid, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE Events SET TicketAmount = TicketAmount - @TicketAmount WHERE EventID = @EventID";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@EventID", eventid);
                command.Parameters.AddWithValue("@TicketAmount", ticketamount);
                command.ExecuteNonQuery();
            }
            updateDataGrid(0);
        }

        // прибавка вернувшихся билетов
        private void IncreaseOfPurchasedTickets(int ticketamount, int eventid, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE Events SET TicketAmount = TicketAmount + @TicketAmount WHERE EventID = @EventID";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@EventID", eventid);
                command.Parameters.AddWithValue("@TicketAmount", ticketamount);
                command.ExecuteNonQuery();
            }
            updateDataGrid(0);
        }

        // вычисление текущего количества купленных билетов
        private int GetTicketCountFromPurchases()
        {
            string query = "SELECT TicketsAmount FROM Purchases WHERE PurchasesID = @PurchasesID";
            int ticketCount = 0;
            using (SqlConnection connection = new(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@PurchasesID", selectedIDPurchases);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        ticketCount = Convert.ToInt32(result);
                    }
                }
            }
            return ticketCount;
        }

        // доп важная логика для обновления покупок
        private void UpdatePurchase(int newTicketAmount, int oldTicketAmount, int eventID, SqlConnection connection, SqlTransaction transaction)
        {
            int difference = newTicketAmount - oldTicketAmount;

            if (difference != 0)
            {
                if (difference > 0) // новое значение больше
                {
                    int availableTickets = GetTicketCount(eventID);
                    if (availableTickets >= difference)
                    {
                        SubtractionOfPurchasedTickets(difference, eventID, connection, transaction);
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно билетов");
                        return;
                    }
                }
                else if (difference < 0) // новое значение меньше
                {
                    IncreaseOfPurchasedTickets(-difference, eventID, connection, transaction);
                }
            }
        }

        // Выбор значений из таблицы
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid? dataGrid = sender as DataGrid;
            DataRowView? dataRowView = dataGrid?.SelectedItem as DataRowView;
            if (dataRowView != null)
            {
                if (dataGrid.Name == "myDataGridEvents")
                {
                    event_name_textbox.Text = dataRowView["EventName"].ToString();
                    event_date_textbox.Text = ((DateTime)dataRowView["EventData"]).ToString("dd.MM.yyyy HH:mm");
                    event_location_textbox.Text = dataRowView["EventLocation"].ToString();
                    event_ticket_price_textbox.Text = dataRowView["TicketPrice"].ToString();
                    event_tickets_amount_textbox.Text = dataRowView["TicketAmount"].ToString();
                    SetImage(dataRowView["EventImage"].ToString());
                    selectedIDEvents = (int)dataRowView["EventID"];
                    add_btn.IsEnabled = false;
                    update_btn.IsEnabled = true;
                    delete_btn.IsEnabled = true;
                }
                else if (dataGrid.Name == "myDataGridUsers")
                {
                    user_name_textbox.Text = dataRowView["UserName"].ToString();
                    user_email_textbox.Text = dataRowView["UserEmail"].ToString();
                    selectedIDUsers = (int)dataRowView["UserID"];
                    add_btn_user.IsEnabled = false;
                    update_btn_user.IsEnabled = true;
                    delete_btn_user.IsEnabled = true;
                }
                else if (dataGrid.Name == "myDataGridPurchases")
                {
                    int eventIdIndex = purchases_event_combobox.Items.IndexOf(dataRowView["EventID"].ToString());
                    int userIdIndex = purchases_user_combobox.Items.IndexOf(dataRowView["UserID"].ToString());
                    purchases_event_combobox.SelectedIndex = eventIdIndex;
                    purchases_user_combobox.SelectedIndex = userIdIndex;
                    purchases_tickets_amount_textbox.Text = dataRowView["TicketsAmount"].ToString();
                    purchases_date_textbox.Text = ((DateTime)dataRowView["PurchaseDate"]).ToString("dd.MM.yyyy HH:mm");
                    purchases_price_textbox.Text = dataRowView["PurchasePrice"].ToString();
                    selectedIDPurchases = (int)dataRowView["PurchasesID"];
                    add_btn_purchases.IsEnabled = false;
                    update_btn_purchases.IsEnabled = true;
                    delete_btn_purchases.IsEnabled = true;
                }

            }
        }

        //изменение направления сортировки
        private void SortFlag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bi.CacheOption = BitmapCacheOption.OnLoad;

                if (sender is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == "SortFlag")
                    {
                        if (upEvents)
                        {
                            bi.UriSource = new Uri("C:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 8\\down-square-svgrepo-com.png", UriKind.RelativeOrAbsolute);
                        }
                        else
                        {
                            bi.UriSource = new Uri("C:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 8\\up-square-svgrepo-com.png", UriKind.RelativeOrAbsolute);
                        }
                        upEvents = !upEvents;
                        bi.EndInit();
                        SortFlag.Source = bi;
                        updateDataGrid(0);
                    }
                    else if (frameworkElement.Name == "SortFlag_user")
                    {
                        if (upUsers)
                        {
                            bi.UriSource = new Uri("C:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 8\\down-square-svgrepo-com.png", UriKind.RelativeOrAbsolute);
                        }
                        else
                        {
                            bi.UriSource = new Uri("C:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 8\\up-square-svgrepo-com.png", UriKind.RelativeOrAbsolute);
                        }
                        upUsers = !upUsers;
                        bi.EndInit();
                        SortFlag_user.Source = bi;
                        updateDataGrid(1);

                    }
                    else if (frameworkElement.Name == "SortFlag_purchases")
                    {
                        if (upPurchases)
                        {
                            bi.UriSource = new Uri("C:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 8\\down-square-svgrepo-com.png", UriKind.RelativeOrAbsolute);
                        }
                        else
                        {
                            bi.UriSource = new Uri("C:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 8\\up-square-svgrepo-com.png", UriKind.RelativeOrAbsolute);
                        }
                        upPurchases = !upPurchases;
                        bi.EndInit();
                        SortFlag_purchases.Source = bi;
                        updateDataGrid(2);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении направления сортировки " + ex.Message);
            }

        }

        // обновление таблицы при смене сортировки
        private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "SortCombobox")
                {
                    updateDataGrid(0);
                }
                else if (frameworkElement.Name == "SortCombobox_user")
                {
                    updateDataGrid(1);
                }
                else if (frameworkElement.Name == "SortCombobox_purchases")
                {
                    updateDataGrid(2);
                }
            }
        }

        // листаем 
        private void nextElementBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "nextElementBtn")
                {
                    MoveSelection(-1, 0);
                }
                else if (frameworkElement.Name == "nextElementBtn_user")
                {
                    MoveSelection(-1, 1);
                }
                else if (frameworkElement.Name == "nextElementBtn_purchases")
                {
                    MoveSelection(-1, 2);
                }
            }
        }

        private void previousElementBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "previousElementBtn")
                {
                    MoveSelection(1, 0);
                }
                else if (frameworkElement.Name == "previousElementBtn_user")
                {
                    MoveSelection(1, 1);
                }
                else if (frameworkElement.Name == "previousElementBtn_purchases")
                {
                    MoveSelection(1, 2);
                }
            }
        }

        private void MoveSelection(int direction, int table)
        {
            int newIndex;
            switch (table)
            {
                case 0:
                    newIndex = myDataGridEvents.SelectedIndex + direction;
                    if (newIndex >= 0 && newIndex < myDataGridEvents.Items.Count)
                    {
                        myDataGridEvents.SelectedIndex = newIndex;
                        myDataGridEvents.ScrollIntoView(myDataGridEvents.SelectedItem);
                    }
                    break;
                case 1:
                    newIndex = myDataGridUsers.SelectedIndex + direction;
                    if (newIndex >= 0 && newIndex < myDataGridUsers.Items.Count)
                    {
                        myDataGridUsers.SelectedIndex = newIndex;
                        myDataGridUsers.ScrollIntoView(myDataGridUsers.SelectedItem);
                    }
                    break;
                case 2:
                    newIndex = myDataGridPurchases.SelectedIndex + direction;
                    if (newIndex >= 0 && newIndex < myDataGridPurchases.Items.Count)
                    {
                        myDataGridPurchases.SelectedIndex = newIndex;
                        myDataGridPurchases.ScrollIntoView(myDataGridPurchases.SelectedItem);
                    }
                    break;
            }
        }

        // заполнение списков айдишников для покупок
        private void CompletionCombobox()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT EventID FROM Events", connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string eventId = row["EventID"].ToString();
                        if (!purchases_event_combobox.Items.Contains(eventId))
                        {
                            purchases_event_combobox.Items.Add(eventId);
                        }
                    }

                    SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT UserID FROM Users", connection);
                    DataTable dataTable1 = new DataTable();
                    adapter1.Fill(dataTable1);
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        string userId = row["UserID"].ToString();
                        if (!purchases_user_combobox.Items.Contains(userId))
                        {
                            purchases_user_combobox.Items.Add(userId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке combobox: {ex.Message} + {ex.StackTrace}");
                }
            }
        }

        // вычисление стоимости покупки и вызов процедуры покупки билетов
        private void purchases_price_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string queryID = "SELECT COUNT(*) FROM Events WHERE EventID = @EventID";
                string selectedItemText = purchases_event_combobox.SelectedItem?.ToString();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = queryID;
                command.CommandType = CommandType.Text;
                command.Parameters.Add("EventID", SqlDbType.Int).Value = Int32.Parse(selectedItemText);
                int count = Convert.ToInt32(command.ExecuteScalar());

                bool condition1 = count > 0; // существует event с указанным id
                bool condition2 = !string.IsNullOrEmpty(purchases_tickets_amount_textbox.Text); // колво билетов заполнено
                bool condition3 = int.TryParse(purchases_tickets_amount_textbox.Text, out int number); // билеты - int
                // condition4 убран, так как проверка наличия билетов выполняется в процедуре

                if (condition1 && condition2 && condition3)
                {
                    int price = number * GetTicketPrice(Int32.Parse(selectedItemText));
                    purchases_price_textbox.Text = $"{price}";

                    int eventID = int.Parse(purchases_event_combobox.SelectedItem.ToString()); // Получаем eventID из combobox
                    int userID = int.Parse(purchases_user_combobox.SelectedItem.ToString()); // Получаем userID из combobox
                    int ticketAmount = int.Parse(purchases_tickets_amount_textbox.Text); // Получаем количество билетов

                    BuyTickets(eventID, userID, ticketAmount); // Вызов процедуры покупки билетов
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обработке покупки " + ex.Message + " " + ex.StackTrace);
            }
        }

        // Процедура для покупки билетов
        private void BuyTickets(int eventID, int userID, int ticketAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("BuyTickets", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EventID", eventID);
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@TicketAmount", ticketAmount);

                        // Получаем результат выполнения процедуры
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string message = reader["Message"].ToString();
                            MessageBox.Show(message);
                        }
                        reader.Close();

                        // Обновляем таблицы Events и Purchases
                        updateDataGrid(0);
                        updateDataGrid(2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вызове процедуры BuyTickets: {ex.Message}");
            }
        }
    }
}