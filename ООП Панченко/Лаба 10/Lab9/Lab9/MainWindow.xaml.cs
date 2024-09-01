using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
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

namespace Lab9
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T FindByID(int id);
        T FirstOrDefault(int id);
        IEnumerable<int> Select();
        bool Any(int id);
    }
    public class EventRepository : IRepository<Event>
    {
        private readonly Lab9Context _context;

        public EventRepository(Lab9Context context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Event.ToList();
        }

        public void Add(Event entity)
        {
            _context.Event.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Event entity)
        {
            _context.Event.Remove(entity);
            _context.SaveChanges();
        }
        public Event FindByID(int id)
        {
            return _context.Event.Find(id);
        }
        public Event FirstOrDefault(int id)
        {
            return _context.Event.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<int> Select()
        {
            return _context.Event.Select(e => e.Id).ToList();
        }
        public bool Any(int id)
        {
            return _context.Event.Any(ev => ev.Id == id);
        }
    }
    public class UserRepository : IRepository<User>
    {
        private readonly Lab9Context _context;

        public UserRepository(Lab9Context context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return  _context.User.ToList();
        }

        public void Add(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
        }
        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            _context.User.Remove(entity);
            _context.SaveChanges();
        }
        public User FindByID(int id)
        {
            return _context.User.Find(id);
        }
        public User FirstOrDefault(int id)
        {
            return _context.User.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<int> Select()
        {
            return _context.User.Select(e => e.Id).ToList();
        }
        public bool Any(int id)
        {
            return _context.User.Any(ev => ev.Id == id);
        }
    }
    public class PurchaseRepository : IRepository<Purchase>
    {
        private readonly Lab9Context _context;

        public PurchaseRepository(Lab9Context context)
        {
            _context = context;
        }

        public IEnumerable<Purchase> GetAll()
        {
            return _context.Purchase.ToList();
        }

        public void Add(Purchase entity)
        {
            _context.Purchase.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Purchase entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Purchase entity)
        {
            _context.Purchase.Remove(entity);
            _context.SaveChanges();
        }
        public Purchase FindByID(int id)
        {
            return _context.Purchase.Find(id);
        }
        public Purchase FirstOrDefault(int id)
        {
            return _context.Purchase.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<int> Select()
        {
            return _context.Purchase.Select(e => e.Id).ToList();
        }
        public bool Any(int id)
        {
            return _context.Purchase.Any(ev => ev.Id == id);
        }

    }
    public class UnitOfWork : IDisposable
    {
        private readonly Lab9Context _context;

        public UnitOfWork()
        {
            _context = new Lab9Context();
            Event = new EventRepository(_context);
            User = new UserRepository(_context);
            Purchase = new PurchaseRepository(_context);
        }

        public EventRepository Event { get; }
        public UserRepository User { get; }
        public PurchaseRepository Purchase { get; }

        public void Save()
        {
             _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

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
        private readonly UnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            updateDataGrid();
            CompletionCombobox();
        }

        // обновление таблицы
        private void updateDataGrid()
        {
            var events = _unitOfWork.Event.GetAll();
            var users = _unitOfWork.User.GetAll();
            var purchases = _unitOfWork.Purchase.GetAll();
            myDataGridEvents.ItemsSource = events;
            myDataGridUsers.ItemsSource = users;
            myDataGridPurchases.ItemsSource = purchases;
        }
        // добавь запись
        private void add_btn_Click(object sender, RoutedEventArgs e)
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
                        _unitOfWork.Event.Add(newevent);
                        add_btn.IsEnabled = false;
                        update_btn.IsEnabled = true;
                        delete_btn.IsEnabled = true;
                        resetAll_Events();
                        updateDataGrid();
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
                        _unitOfWork.User.Add(newuser);
                        add_btn_user.IsEnabled = false;
                        update_btn_user.IsEnabled = true;
                        delete_btn_user.IsEnabled = true;
                        resetAll_Users();
                        updateDataGrid();
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
                        Event selectedEvent = _unitOfWork.Event.FindByID(eventId);
                        int userId = Int32.Parse(purchases_user_combobox.SelectedItem?.ToString());
                        User selectedUser = _unitOfWork.User.FindByID(userId);

                        Purchase newpurchase = new Purchase
                        {
                            Event = selectedEvent,
                            User = selectedUser,
                            TicketAmount = Int32.Parse(purchases_tickets_amount_textbox.Text),
                            Date = DateTime.Parse(purchases_date_textbox.Text),
                            Price = Int32.Parse(purchases_price_textbox.Text)
                        };
                        _unitOfWork.Purchase.Add(newpurchase);
                        add_btn_purchases.IsEnabled = false;
                        update_btn_purchases.IsEnabled = true;
                        delete_btn_purchases.IsEnabled = true;
                        
                        SubtractionOfPurchasedTickets(Int32.Parse(purchases_tickets_amount_textbox.Text), Int32.Parse(purchases_event_combobox.SelectedItem?.ToString()));
                        
                        resetAll_Purchases();
                        updateDataGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении данных в таблицу " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
                    }
                }
            }
        }
        // обновление записи
        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "update_btn" && !string.IsNullOrEmpty(event_name_textbox.Text) && !string.IsNullOrEmpty(event_date_textbox.Text) &&
                    !string.IsNullOrEmpty(event_location_textbox.Text) && !string.IsNullOrEmpty(event_ticket_price_textbox.Text)
                    && !string.IsNullOrEmpty(event_tickets_amount_textbox.Text) && !string.IsNullOrEmpty(event_description_textbox.Text))
                {
                    var entity = _unitOfWork.Event.FirstOrDefault(selectedIDEvents);
                    entity.Name = event_name_textbox.Text;
                    entity.Date = DateTime.Parse(event_date_textbox.Text);
                    entity.Location = event_location_textbox.Text;
                    entity.TicketPrice = Int32.Parse(event_ticket_price_textbox.Text);
                    entity.TicketAmount = Int32.Parse(event_tickets_amount_textbox.Text);
                    entity.Description = event_description_textbox.Text;
                    _unitOfWork.Save();
                    resetAll_Events();
                    updateDataGrid();
                }
                else if (frameworkElement.Name == "update_btn_user" && !string.IsNullOrEmpty(user_name_textbox.Text) && !string.IsNullOrEmpty(user_email_textbox.Text))
                {
                    var entity = _unitOfWork.User.FirstOrDefault(selectedIDUsers);
                    entity.Name = user_name_textbox.Text;
                    entity.Email = user_email_textbox.Text;
                    _unitOfWork.Save();
                    resetAll_Users();
                    updateDataGrid();
                }
                else if (frameworkElement.Name == "update_btn_purchases" && !string.IsNullOrEmpty(purchases_user_combobox.SelectedItem?.ToString()) && !string.IsNullOrEmpty(purchases_date_textbox.Text) && !string.IsNullOrEmpty(purchases_price_textbox.Text))
                {
                    int eventId = Int32.Parse(purchases_event_combobox.SelectedItem?.ToString());
                    Event selectedEvent = _unitOfWork.Event.FirstOrDefault(eventId);
                    int userId = Int32.Parse(purchases_user_combobox.SelectedItem?.ToString());
                    User selectedUser = _unitOfWork.User.FirstOrDefault(userId);

                    var entity = _unitOfWork.Purchase.FirstOrDefault(selectedIDPurchases);
                    UpdatePurchase(Int32.Parse(purchases_tickets_amount_textbox.Text), Int32.Parse(purchases_event_combobox.SelectedItem?.ToString()));
                    entity.Event = selectedEvent;
                    entity.User = selectedUser;
                    entity.TicketAmount = Int32.Parse(purchases_tickets_amount_textbox.Text);
                    entity.Date = DateTime.Parse(purchases_date_textbox.Text);
                    entity.Price = Int32.Parse(purchases_price_textbox.Text);
                    _unitOfWork.Save();

                    resetAll_Purchases();
                    updateDataGrid();
                }
                CompletionCombobox();
            }
        }

        // вычитание купленных билетов из Event
        private void SubtractionOfPurchasedTickets(int ticketamount, int eventid)
        {
            
            try
            {
                var entity = _unitOfWork.Event.FirstOrDefault(eventid);
                int currentTicketAmount = entity.TicketAmount;
                entity.TicketAmount = currentTicketAmount - ticketamount;
                _unitOfWork.Save();
                updateDataGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка при вычитании купленных билетов из Event " + ex.Message + " " + ex.StackTrace + " " + ex.InnerException.Message);
            }
            
        }

        // доп важная логика для обновления покупок
        private void UpdatePurchase(int newTicketAmount, int eventID)
        {
            
            try
            {
                var entity = _unitOfWork.Purchase.FirstOrDefault(selectedIDPurchases);

                int difference = newTicketAmount - entity.TicketAmount;

                if (difference != 0)
                {
                    if (difference > 0) // новое значение больше
                    {
                        int availableTickets = _unitOfWork.Event.FirstOrDefault(eventID).TicketAmount;
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
                        var eventticket = _unitOfWork.Event.FirstOrDefault(eventID);
                        int currentTicketCount = eventticket.TicketAmount;
                        eventticket.TicketAmount = currentTicketCount - difference;
                        _unitOfWork.Save();
                        updateDataGrid();
                    }
                }
                _unitOfWork.Save();
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
            updateDataGrid();
        }
        private void resetAll_Users()
        {
            user_name_textbox.Text = "";
            user_email_textbox.Text = "";
            add_btn_user.IsEnabled = true;
            update_btn_user.IsEnabled = false;
            delete_btn_user.IsEnabled = false;
            myDataGridUsers.SelectedItem = null;
            updateDataGrid();
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
            updateDataGrid();

        }
        // удаление записей
        async private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement frameworkElement)
            {
                if (frameworkElement.Name == "delete_btn")
                {
                    var entity = _unitOfWork.Event.FirstOrDefault(selectedIDEvents);
                    _unitOfWork.Event.Remove(entity);
                    resetAll_Events();
                    updateDataGrid();
                }
                else if (frameworkElement.Name == "delete_btn_user")
                {
                    var entity = _unitOfWork.User.FirstOrDefault(selectedIDUsers);
                    _unitOfWork.User.Remove(entity);
                    resetAll_Users();
                    updateDataGrid();
                }
                else if (frameworkElement.Name == "delete_btn_purchases")
                {
                    var entity = _unitOfWork.Purchase.FirstOrDefault(selectedIDPurchases);
                    var eventticket = _unitOfWork.Event.FirstOrDefault(Int32.Parse(purchases_event_combobox.SelectedItem.ToString()));
                    eventticket.TicketAmount += entity.TicketAmount;
                    _unitOfWork.Purchase.Remove(entity);
                    resetAll_Purchases();
                    updateDataGrid();
                }
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
        // заполнение списков айдишников для покупок
        private void CompletionCombobox()
        {
            try
            {
                    purchases_event_combobox.Items.Clear();
                    purchases_user_combobox.Items.Clear();

                    var eventIds = _unitOfWork.Event.Select();
                    foreach (var eventId in eventIds)
                    {
                        if (!purchases_event_combobox.Items.Contains(eventId))
                        {
                            purchases_event_combobox.Items.Add(eventId);
                        }
                    }

                    var userIds = _unitOfWork.User.Select();
                    foreach (var userId in userIds)
                    {
                        if (!purchases_user_combobox.Items.Contains(userId))
                        {
                            purchases_user_combobox.Items.Add(userId);
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
                string selectedItemText = purchases_event_combobox.SelectedItem?.ToString();

                bool condition1 = _unitOfWork.Event.Any(Int32.Parse(selectedItemText)); // такое событие существует
                bool condition2 = !string.IsNullOrEmpty(purchases_tickets_amount_textbox.Text); // колво билетов заполнено
                bool condition3 = int.TryParse(purchases_tickets_amount_textbox.Text, out int number); // билеты - int
                bool condition4 = number < _unitOfWork.Event.FirstOrDefault(Int32.Parse(selectedItemText)).TicketPrice;
                if (condition1 && condition2 && condition3 && condition4)
                {
                    int price = number * _unitOfWork.Event.FirstOrDefault(Int32.Parse(selectedItemText)).TicketPrice;
                    purchases_price_textbox.Text = $"{price}";
                }
                else
                {
                    MessageBox.Show("Невозможно подсчитать стоимость покупки");
                    purchases_price_textbox.Text = string.Empty;
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
