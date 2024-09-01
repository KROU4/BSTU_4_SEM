Use TicketsDB;

CREATE TABLE Events (
    event_id INT PRIMARY KEY,
    event_name VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_location VARCHAR(255) NOT NULL,
    ticket_price DECIMAL(10, 2) NOT NULL,
	ticket_amount DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(100) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NOT NULL
);

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY,
    event_id INT,
	customer_id INT,
	ticket_amount DECIMAL(10, 2) NOT NULL,
    transaction_date TIMESTAMP,
	transaction_price DECIMAL(10, 2) NOT NULL,
    payment_method VARCHAR(50) NOT NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id),
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

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
