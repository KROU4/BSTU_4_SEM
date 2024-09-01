    using System;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Identity.Client;
    using Microsoft.VisualBasic.ApplicationServices;
    using static System.Runtime.InteropServices.JavaScript.JSType;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    namespace Lab9
    {
        public class Lab9Context : DbContext
        {
            public DbSet<Event> Event { get; set; }
            public DbSet<Purchase> Purchase { get; set; }
            public DbSet<User> User { get; set; }
            public Lab9Context() => Database.EnsureCreated();
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);
            }
        }
        public partial class MainWindow : Window
        {
            private int selectedIDEvents = 0;
            private int selectedIDUsers = 0;
            private int selectedIDPurchases = 0;
            private bool upEvents = true;
            private bool upUsers = true;
            private bool upPurchases = true;

            public MainWindow()
            {
                InitializeComponent();
                CompletionCombobox();
            }

            // обновление таблицы
            private void updateDataGrid(int n)
            {

                try
                {
                    using (Lab9Context db = new())
                    {
                        if (n == 0)
                        {
                            int selectedIndex = SortCombobox.SelectedIndex;
                            if (upEvents)
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        var data = db.Event.OrderBy(e => e.Id).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 1:
                                        data = db.Event.OrderBy(e => e.Name).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 2:
                                        data = db.Event.OrderBy(e => e.Date).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 3:
                                        data = db.Event.OrderBy(e => e.Location).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 4:
                                        data = db.Event.OrderBy(e => e.TicketPrice).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 5:
                                        data = db.Event.OrderBy(e => e.TicketAmount).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 6:
                                        data = db.Event.OrderBy(e => e.Description).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;

                                }
                            }
                            else
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        var data = db.Event.OrderByDescending(e => e.Id).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 1:
                                        data = db.Event.OrderByDescending(e => e.Name).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 2:
                                        data = db.Event.OrderByDescending(e => e.Date).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 3:
                                        data = db.Event.OrderByDescending(e => e.Location).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 4:
                                        data = db.Event.OrderByDescending(e => e.TicketPrice).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 5:
                                        data = db.Event.OrderByDescending(e => e.TicketAmount).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;
                                    case 6:
                                        data = db.Event.OrderByDescending(e => e.Description).ToList();
                                        myDataGridEvents.ItemsSource = data;
                                        break;

                                }
                            }
                        }
                        else if (n == 1)
                        {
                            int selectedIndex = SortCombobox_user.SelectedIndex;
                            if (upUsers)
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        var data = db.User.OrderBy(e => e.Id).ToList();
                                        myDataGridUsers.ItemsSource = data;
                                        break;
                                    case 1:
                                        data = db.User.OrderBy(e => e.Name).ToList();
                                        myDataGridUsers.ItemsSource = data;
                                        break;
                                    case 2:
                                        data = db.User.OrderBy(e => e.Email).ToList();
                                        myDataGridUsers.ItemsSource = data;
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        var data = db.User.OrderByDescending(e => e.Id).ToList();
                                        myDataGridUsers.ItemsSource = data;
                                        break;
                                    case 1:
                                        data = db.User.OrderByDescending(e => e.Name).ToList();
                                        myDataGridUsers.ItemsSource = data;
                                        break;
                                    case 2:
                                        data = db.User.OrderByDescending(e => e.Email).ToList();
                                        myDataGridUsers.ItemsSource = data;
                                        break;
                                }
                            }
                        }
                        else if (n == 2)
                        {
                            int selectedIndex = SortCombobox_purchases.SelectedIndex;
                            if (upPurchases)
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        var data = db.Purchase.OrderBy(e => e.Id).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 1:
                                        data = db.Purchase.OrderBy(e => e.Event.Id).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 2:
                                        data = db.Purchase.OrderBy(e => e.User.Id).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 3:
                                        data = db.Purchase.OrderBy(e => e.TicketAmount).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 4:
                                        data = db.Purchase.OrderBy(e => e.Date).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 5:
                                        data = db.Purchase.OrderBy(e => e.Price).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedIndex)
                                {
                                    case 0:
                                        var data = db.Purchase.OrderByDescending(e => e.Id).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 1:
                                        data = db.Purchase.OrderByDescending(e => e.EventId).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 2:
                                        data = db.Purchase.OrderByDescending(e => e.UserId).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 3:
                                        data = db.Purchase.OrderByDescending(e => e.TicketAmount).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 4:
                                        data = db.Purchase.OrderByDescending(e => e.Date).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                    case 5:
                                        data = db.Purchase.OrderByDescending(e => e.Price).ToList();
                                        myDataGridPurchases.ItemsSource = data;
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ошибка при загрузке данных в таблицу " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }
            }
            // добавь запись
            async private void add_btn_Click(object sender, RoutedEventArgs e)
            {
                using (Lab9Context db = new())
                {
                    if (sender is FrameworkElement frameworkElement)
                    {
                        if (frameworkElement.Name == "add_btn" && !string.IsNullOrEmpty(event_name_textbox.Text) && !string.IsNullOrEmpty(event_date_textbox.Text) &&
                            !string.IsNullOrEmpty(event_location_textbox.Text) && !string.IsNullOrEmpty(event_ticket_price_textbox.Text)
                            && !string.IsNullOrEmpty(event_tickets_amount_textbox.Text) && !string.IsNullOrEmpty(event_description_textbox.Text))
                        {
                            try
                            {
                                Event newevent = new Event
                                {
                                    Name = event_name_textbox.Text,
                                    Date = DateTime.Parse(event_date_textbox.Text),
                                    Location = event_location_textbox.Text,
                                    TicketPrice = Int32.Parse(event_ticket_price_textbox.Text),
                                    TicketAmount = Int32.Parse(event_tickets_amount_textbox.Text),
                                    Description = event_description_textbox.Text
                                };
                                await db.Event.AddRangeAsync(newevent);
                                await db.SaveChangesAsync();
                                add_btn.IsEnabled = false;
                                update_btn.IsEnabled = true;
                                delete_btn.IsEnabled = true;
                                resetAll_Events();
                                updateDataGrid(0);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при добавлении данных в таблицу " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                            }


                        }
                        else if (frameworkElement.Name == "add_btn_user" && !string.IsNullOrEmpty(user_name_textbox.Text) && !string.IsNullOrEmpty(user_email_textbox.Text))
                        {
                            try
                            {
                                User newuser = new User
                                {
                                    Name = user_name_textbox.Text,
                                    Email = user_email_textbox.Text
                                };
                                await db.User.AddRangeAsync(newuser);
                                await db.SaveChangesAsync();
                                add_btn_user.IsEnabled = false;
                                update_btn_user.IsEnabled = true;
                                delete_btn_user.IsEnabled = true;
                                resetAll_Users();
                                updateDataGrid(1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при добавлении данных в таблицу " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                            }

                        }
                        else if (frameworkElement.Name == "add_btn_purchases" && !string.IsNullOrEmpty(purchases_user_combobox.SelectedItem?.ToString()) && !string.IsNullOrEmpty(purchases_date_textbox.Text) && !string.IsNullOrEmpty(purchases_price_textbox.Text))
                        {
                            try
                            {
                                int eventId = Int32.Parse(purchases_event_combobox.SelectedItem?.ToString());
                                Event selectedEvent = await db.Event.FindAsync(eventId);
                                int userId = Int32.Parse(purchases_user_combobox.SelectedItem?.ToString());
                                User selectedUser = await db.User.FindAsync(userId);

                                Purchase newpurchase = new Purchase
                                {
                                    Event = selectedEvent,
                                    User = selectedUser,
                                    TicketAmount = Int32.Parse(purchases_tickets_amount_textbox.Text),
                                    Date = DateTime.Parse(purchases_date_textbox.Text),
                                    Price = Int32.Parse(purchases_price_textbox.Text)
                                };
                                await db.Purchase.AddRangeAsync(newpurchase);
                                await db.SaveChangesAsync();
                                add_btn_purchases.IsEnabled = false;
                                update_btn_purchases.IsEnabled = true;
                                delete_btn_purchases.IsEnabled = true;
                                // вычитание купленных билетов из Event
                                SubtractionOfPurchasedTickets(Int32.Parse(purchases_tickets_amount_textbox.Text), Int32.Parse(purchases_event_combobox.SelectedItem?.ToString()));
                                resetAll_Purchases();
                                updateDataGrid(2);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при добавлении данных в таблицу " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                            }


                        }
                        CompletionCombobox();
                    }
                }
            }
            // вычитание купленных билетов из Event
            async private void SubtractionOfPurchasedTickets(int ticketamount, int eventid)
            {
                try
                {
                    using (Lab9Context db = new())
                    {
                        var entity = db.Event.FirstOrDefault(e => e.Id == eventid);
                        int currentTicketAmount = entity.TicketAmount;
                        entity.TicketAmount = currentTicketAmount - ticketamount;
                        await db.SaveChangesAsync();
                        updateDataGrid(0);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ошибка при вычитании купленных билетов из Event " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }
            }

            // обновление записи
            async private void update_btn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    using (Lab9Context db = new())
                    {

                        if (sender is FrameworkElement frameworkElement)
                        {
                            if (frameworkElement.Name == "update_btn" && !string.IsNullOrEmpty(event_name_textbox.Text) && !string.IsNullOrEmpty(event_date_textbox.Text) &&
                                !string.IsNullOrEmpty(event_location_textbox.Text) && !string.IsNullOrEmpty(event_ticket_price_textbox.Text)
                                && !string.IsNullOrEmpty(event_tickets_amount_textbox.Text) && !string.IsNullOrEmpty(event_description_textbox.Text))
                            {
                                var entity = db.Event.FirstOrDefault(e => e.Id == selectedIDEvents);
                                entity.Name = event_name_textbox.Text;
                                entity.Date = DateTime.Parse(event_date_textbox.Text);
                                entity.Location = event_location_textbox.Text;
                                entity.TicketPrice = Int32.Parse(event_ticket_price_textbox.Text);
                                entity.TicketAmount = Int32.Parse(event_tickets_amount_textbox.Text);
                                entity.Description = event_description_textbox.Text;
                                await db.SaveChangesAsync();
                                resetAll_Events();
                                updateDataGrid(0);
                            }
                            else if (frameworkElement.Name == "update_btn_user" && !string.IsNullOrEmpty(user_name_textbox.Text) && !string.IsNullOrEmpty(user_email_textbox.Text))
                            {
                                var entity = db.User.FirstOrDefault(e => e.Id == selectedIDUsers);
                                entity.Name = user_name_textbox.Text;
                                entity.Email = user_email_textbox.Text;
                                await db.SaveChangesAsync();
                                resetAll_Users();
                                updateDataGrid(1);
                            }
                            else if (frameworkElement.Name == "update_btn_purchases" && !string.IsNullOrEmpty(purchases_user_combobox.SelectedItem?.ToString()) && !string.IsNullOrEmpty(purchases_date_textbox.Text) && !string.IsNullOrEmpty(purchases_price_textbox.Text))
                            {
                                int eventId = Int32.Parse(purchases_event_combobox.SelectedItem?.ToString());
                                Event selectedEvent = await db.Event.FindAsync(eventId);
                                int userId = Int32.Parse(purchases_user_combobox.SelectedItem?.ToString());
                                User selectedUser = await db.User.FindAsync(userId);

                                var entity = db.Purchase.FirstOrDefault(e => e.Id == selectedIDPurchases);
                                UpdatePurchase(Int32.Parse(purchases_tickets_amount_textbox.Text), Int32.Parse(purchases_event_combobox.SelectedItem?.ToString()));
                                entity.Event = selectedEvent;
                                entity.User = selectedUser;
                                entity.TicketAmount = Int32.Parse(purchases_tickets_amount_textbox.Text);
                                entity.Date = DateTime.Parse(purchases_date_textbox.Text);
                                entity.Price = Int32.Parse(purchases_price_textbox.Text);
                                await db.SaveChangesAsync();

                                // доп важная логика для изменения событий при обновлении покупок
                                resetAll_Purchases();
                                updateDataGrid(2);
                            }
                        }
                        CompletionCombobox();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ошибка при обновлении данных " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }
            }
            // доп важная логика для обновления покупок
            async private void UpdatePurchase(int newTicketAmount, int eventID)
            {
                try
                {
                    using (Lab9Context db = new())
                    {

                        var entity = db.Purchase.FirstOrDefault(e => e.Id == selectedIDPurchases);

                        int difference = newTicketAmount - entity.TicketAmount;

                        if (difference != 0)
                        {
                            if (difference > 0) // новое значение больше
                            {
                                int availableTickets = db.Event.FirstOrDefault(e => e.Id == eventID).TicketAmount;
                                if (availableTickets >= difference)
                                {
                                    SubtractionOfPurchasedTickets(difference, eventID);
                                }
                                else
                                {
                                    MessageBox.Show("Недостаточно билетов");
                                    return;
                                }
                            }
                            else if (difference < 0) // новое значение меньше
                            {
                                var eventticket = db.Event.FirstOrDefault(e => e.Id == eventID);
                                int currentTicketCount = eventticket.TicketAmount;
                                eventticket.TicketAmount = currentTicketCount - difference;
                                await db.SaveChangesAsync();
                                updateDataGrid(0);
                            }
                        }
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ошибка в доп логике для обновления покупок " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }

            }

            // обнуление полей
            private void resetAll_Events()
            {
                event_name_textbox.Text = "";
                event_date_textbox.Text = "";
                event_location_textbox.Text = "";
                event_ticket_price_textbox.Text = "";
                event_tickets_amount_textbox.Text = "";
                event_description_textbox.Text = "";
                add_btn.IsEnabled = true;
                update_btn.IsEnabled = false;
                delete_btn.IsEnabled = false;
                myDataGridEvents.SelectedItem = null;
                updateDataGrid(0);
            }
            private void resetAll_Users()
            {
                user_name_textbox.Text = "";
                user_email_textbox.Text = "";
                add_btn_user.IsEnabled = true;
                update_btn_user.IsEnabled = false;
                delete_btn_user.IsEnabled = false;
                myDataGridUsers.SelectedItem = null;
                updateDataGrid(1);
            }
            private void resetAll_Purchases()
            {
                purchases_event_combobox.SelectedIndex = -1;
                purchases_user_combobox.SelectedIndex = -1;

                purchases_tickets_amount_textbox.Text = "";
                purchases_date_textbox.Text = "";
                purchases_price_textbox.Text = "";
                add_btn_purchases.IsEnabled = true;
                update_btn_purchases.IsEnabled = false;
                delete_btn_purchases.IsEnabled = false;
                myDataGridPurchases.SelectedItem = null;
                updateDataGrid(2);

            }
            // удаление записей
            async private void delete_btn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    using (Lab9Context db = new())
                    {
                        if (sender is FrameworkElement frameworkElement)
                        {
                            if (frameworkElement.Name == "delete_btn")
                            {
                                var entity = db.Event.FirstOrDefault(e => e.Id == selectedIDEvents);
                                db.Event.Remove(entity);
                                string sqlQuery = $"DELETE FROM Purchase WHERE EventId = {selectedIDEvents}";
                                int deletedCount = db.Database.ExecuteSqlRaw(sqlQuery);
                                if (deletedCount > 0)
                                {
                                    MessageBox.Show($"Было удалено {deletedCount} записей покупок");
                                }

                                await db.SaveChangesAsync();
                                resetAll_Events();
                                updateDataGrid(0);
                            }
                            else if (frameworkElement.Name == "delete_btn_user")
                            {
                                var entity = db.User.FirstOrDefault(e => e.Id == selectedIDUsers);
                                db.User.Remove(entity);

                                string sqlQuery = $"DELETE FROM Purchase WHERE UserId = {selectedIDUsers}";
                                int deletedCount = db.Database.ExecuteSqlRaw(sqlQuery);
                                if (deletedCount > 0)
                                {
                                    MessageBox.Show($"Было удалено {deletedCount} записей покупок");
                                }

                                await db.SaveChangesAsync();
                                resetAll_Users();
                                updateDataGrid(1);
                                updateDataGrid(2);
                            }
                            else if (frameworkElement.Name == "delete_btn_purchases")
                            {
                                var entity = db.Purchase.FirstOrDefault(e => e.Id == selectedIDPurchases);

                                var eventticket = db.Event.FirstOrDefault(e => e.Id == Int32.Parse(purchases_event_combobox.SelectedItem.ToString()));
                                eventticket.TicketAmount += entity.TicketAmount;

                                db.Purchase.Remove(entity);
                                await db.SaveChangesAsync();
                                resetAll_Purchases();
                                updateDataGrid(2);
                                updateDataGrid(0);
                            }
                        }
                        CompletionCombobox();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ошибка при удалении данных " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }

            }
            // Выбор значений из таблицы
            private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                try
                {
                    DataGrid dataGrid = sender as DataGrid;
                    if (dataGrid != null && dataGrid.SelectedItem != null)
                    {
                        if (dataGrid.Name == "myDataGridEvents")
                        {
                            Event selectedEvent = (Event)dataGrid.SelectedItem;
                            event_name_textbox.Text = selectedEvent.Name;
                            event_date_textbox.Text = ((DateTime)selectedEvent.Date).ToString("dd.MM.yyyy HH:mm");
                            event_location_textbox.Text = selectedEvent.Location;
                            event_ticket_price_textbox.Text = selectedEvent.TicketPrice.ToString();
                            event_tickets_amount_textbox.Text = selectedEvent.TicketAmount.ToString();
                            event_description_textbox.Text = selectedEvent.Description;

                            selectedIDEvents = selectedEvent.Id;
                            add_btn.IsEnabled = false;
                            update_btn.IsEnabled = true;
                            delete_btn.IsEnabled = true;
                        }
                        else if (dataGrid.Name == "myDataGridUsers")
                        {
                            User selectedUser = (User)dataGrid.SelectedItem;
                            user_name_textbox.Text = selectedUser.Name;
                            user_email_textbox.Text = selectedUser.Email;

                            selectedIDUsers = selectedUser.Id;
                            add_btn_user.IsEnabled = false;
                            update_btn_user.IsEnabled = true;
                            delete_btn_user.IsEnabled = true;
                        }
                        else if (dataGrid.Name == "myDataGridPurchases")
                        {
                            Purchase selectedPurchase = (Purchase)dataGrid.SelectedItem;
                            purchases_event_combobox.SelectedItem = selectedPurchase.EventId;
                            purchases_user_combobox.SelectedItem = selectedPurchase.UserId;
                            purchases_tickets_amount_textbox.Text = selectedPurchase.TicketAmount.ToString();
                            purchases_date_textbox.Text = ((DateTime)selectedPurchase.Date).ToString("dd.MM.yyyy HH:mm");
                            purchases_price_textbox.Text = selectedPurchase.Price.ToString();

                            selectedIDPurchases = selectedPurchase.Id;
                            add_btn_purchases.IsEnabled = false;
                            update_btn_purchases.IsEnabled = true;
                            delete_btn_purchases.IsEnabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выборе значений из таблицы " + ex.Message + " " + ex.StackTrace);
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
                    MessageBox.Show("Ошибка при изменении направления сортировки " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }

            }
            // обновление таблицы при смене сортировки
            private void SortCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при изменении направления сортировки " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }
            }
            // заполнение списков айдишников для покупок
            private void CompletionCombobox()
            {
                try
                {
                    using (Lab9Context db = new())
                    {
                        purchases_event_combobox.Items.Clear();
                        purchases_user_combobox.Items.Clear();

                        var eventIds = db.Event.Select(e => e.Id).ToList();
                        foreach (var eventId in eventIds)
                        {
                            if (!purchases_event_combobox.Items.Contains(eventId))
                            {
                                purchases_event_combobox.Items.Add(eventId);
                            }
                        }

                        var userIds = db.User.Select(u => u.Id).ToList();
                        foreach (var userId in userIds)
                        {
                            if (!purchases_user_combobox.Items.Contains(userId))
                            {
                                purchases_user_combobox.Items.Add(userId);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке combobox: {ex.Message} + {ex.StackTrace} + {ex.InnerException.Message}");
                }
            }
            // вычисление стоимости покупки
            private void purchases_price_btn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    using (Lab9Context db = new())
                    {
                        string selectedItemText = purchases_event_combobox.SelectedItem?.ToString();

                        bool condition1 = db.Event.Any(ev => ev.Id == Int32.Parse(selectedItemText)); // такое событие существует
                        bool condition2 = !string.IsNullOrEmpty(purchases_tickets_amount_textbox.Text); // колво билетов заполнено
                        bool condition3 = int.TryParse(purchases_tickets_amount_textbox.Text, out int number); // билеты - int
                        bool condition4 = number < db.Event.FirstOrDefault(e => e.Id == Int32.Parse(selectedItemText)).TicketAmount; // колво оставшихся билетов меньше
                        if (condition1 && condition2 && condition3 && condition4)
                        {
                            int price = number * db.Event.FirstOrDefault(e => e.Id == Int32.Parse(selectedItemText)).TicketPrice;
                            purchases_price_textbox.Text = $"{price}";
                        }
                        else
                        {
                            MessageBox.Show("Невозможно подсчитать стоимость покупки");
                            purchases_price_textbox.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при вычислении стоимости покупки " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
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
            // сброс стоимости при изменении выбора
            private void comboBox1_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
            {
                purchases_price_textbox.Text = string.Empty;
            }
            private void purchases_tickets_amount_textbox_TextChanged(object sender, TextChangedEventArgs e)
            {
                purchases_price_textbox.Text = string.Empty;
            }
            // поиск
            private void search_btn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    using (Lab9Context db = new())
                    {
                        string? searchName = event_name_textbox_search.Text;
                        string? minPriceText = event_price_textbox_search1.Text;
                        string? maxPriceText = event_price_textbox_search2.Text;

                        bool hasPriceFilter = !string.IsNullOrWhiteSpace(minPriceText) && !string.IsNullOrWhiteSpace(maxPriceText);
                        if (!string.IsNullOrWhiteSpace(searchName) && hasPriceFilter)
                        {
                            if (double.TryParse(minPriceText, out double minPrice) &&
                                double.TryParse(maxPriceText, out double maxPrice) &&
                                minPrice < maxPrice)
                            {

                                var events = db.Event.Where(p => EF.Functions.Like(p.Name!, $"%{searchName}%"))
                                                 .Where(p => p.TicketPrice >= (string.IsNullOrWhiteSpace(minPriceText) ? 0 : int.Parse(minPriceText)))
                                                 .Where(p => p.TicketPrice <= (string.IsNullOrWhiteSpace(maxPriceText) ? int.MaxValue : int.Parse(maxPriceText))).ToList();
                                myDataGridEvents.ItemsSource = events;
                            }
                            else
                            {
                                MessageBox.Show("Минимальная цена не может быть больше максимальной");
                            }
                        }

                        else if (!string.IsNullOrWhiteSpace(searchName))
                        {
                            var events = db.Event.Where(p => EF.Functions.Like(p.Name!, $"%{searchName}%")).ToList();
                            myDataGridEvents.ItemsSource = events;
                        }

                        else if (hasPriceFilter)
                        {
                            if (double.TryParse(minPriceText, out double minPrice) &&
                                double.TryParse(maxPriceText, out double maxPrice) &&
                                minPrice < maxPrice)
                            {

                                var events = db.Event.Where(p => p.TicketPrice >= (string.IsNullOrWhiteSpace(minPriceText) ? 0 : int.Parse(minPriceText)))
                                                 .Where(p => p.TicketPrice <= (string.IsNullOrWhiteSpace(maxPriceText) ? int.MaxValue : int.Parse(maxPriceText))).ToList();
                                myDataGridEvents.ItemsSource = events;
                            }
                            else
                            {
                                MessageBox.Show("Минимальная цена не может быть больше максимальной");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите хотя бы один критерий для поиска");
                            updateDataGrid(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при поиске " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                }

            }
        }
        public class Event
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public DateTime? Date { get; set; }
            public string? Location { get; set; }
            public int TicketPrice { get; set; }
            public int TicketAmount { get; set; }
            public string? Description { get; set; }
            public List<Purchase> Purchase { get; set; } = new();
        }
        public class Purchase
        {
            public int Id { get; set; }
            public int EventId { get; set; } // внешний ключ
            public Event? Event { get; set; }    // навигационное свойство
            public int UserId { get; set; } // внешний ключ
            public User? User { get; set; }    // навигационное свойство
            public int TicketAmount { get; set; }
            public DateTime? Date { get; set; }
            public int Price { get; set; }
        }
        public class User
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public List<Purchase> Purchase { get; set; } = new();
        }
    }
