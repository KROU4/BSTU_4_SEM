import cx_Oracle

# Connect to the database
connection = cx_Oracle.connect("system", "Dim123as", "localhost")

try:
    # Создание курсора
    cursor = connection.cursor()

    # Начало вставки с UserID, начиная с 2
    start_userid = 2

    # Вставка строк с UserID, начиная с start_userid и заканчивая start_userid + 99999
    for i in range(start_userid, start_userid + 100000):
        # Формирование уникального значения для каждой ячейки путем добавления номера текущей итерации
        unique_userid = str(i)
        unique_email = "test" + str(i) + "@gmail.com"
        
        cursor.execute("""
            INSERT INTO Users (UserID, UserName, Email, Password)
            VALUES (:UserID, :UserName, :Email, 'Test123')
        """, {'UserID': unique_userid, 'UserName': unique_userid, 'Email': unique_email})

    # Подтверждение транзакции
    connection.commit()
    print("Данные успешно вставлены.")

except cx_Oracle.Error as error:
    print("Ошибка:", error)
    # Откат транзакции в случае ошибки
    connection.rollback()

finally:
    # Закрытие курсора и соединения
    cursor.close()
    connection.close()