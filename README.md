##### DM-DMS

# Божко Яна, 253504
# Тема: Отель

## Функциональные требования
### Авторизация/аутентификация пользователя.
Присутствует регистрация и аутентификация пользователей через добавление в таблицу User.

### Система ролей.
В приложении предусмотрено нессколько ролей:

1. Супер-админ
2. Администратор
3. Клиент
4. Пользователь

Изначально человек, регистрируясь на сайте становиться пользователем, после может создать Client, на которого и будет совершаться резервирование.

Для того, чтобы пользователь был зарегестрирован как администратор, супер-админ должен добавить его в таблицу Contact. Администратор не теряет возможности создавать Client.

### Управление пользователями (CRUD).
#### Возможности супер-админа:
1. Создание, просмотр, редактирование, удаление всех таблиц
#### Возможности администратора:
1. Создание, просмотр, редактирование, удаление Room, RoomCategory, News, Vacancy, About, PromoCode, Client, Reservation.
2. Просмотр User, CRUD, Payment, Position, EmployeePosition, Action, Data.
3. Просмотр, редактирование ReservationPayment, Contact.
#### Возможности клиента:
1. Создание, просмотр, редактирование, удаление Client.
2. Просмотр ReservationPayment, Room, RoomCategory, News, Vacancy, About, PromoCode.
3. Просмотр, создание Reservation.
#### Возможности пользователя:
1. Просмотр Room, RoomCategory, News, Vacancy, About, PromoCode.
3. Создание, просмотр, редактирование, удаление Client.

### Журналирование  действий пользователя.
В базе данных имеется таблица, хранящая все возможные действия CRUD (Action).

Также есть таблица для хранения данных о моделях, которые можно изменить (Data).

Для журналирования действий используется общая таблица CRUD, в которой хранятся тип действия, модель, дата изменения и человек, его совершивший.
## Cписок таблиц для БД:
### 1. Room
#### Поля:
1. Room_Id         [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Category_Id     [FK: RoomCategory] INT                      NOT NULL                 (один ко многим)
3. Room_Number                        TINYINT                  NOT NULL
4. Capacity                           INT                      NOT NULL
5. Description                        VARCHAR(max_length=120)  NOT NULL
6. Photo                              VARCHAR(max_length=220)  NULL
   
### 2. RoomCategory
#### Поля:
1. Category_Id     [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Name                               VARCHAR(max_length=20)   NOT NULL
3. Description                        VARCHAR(max_length=120)  NULL
4. Price                              FLOAT                    NOT NULL
   
### 3. News
#### Поля:
1. News_Id         [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Title                              VARCHAR(max_length=50)   NOT NULL
3. Content                            VARCHAR(max_length=120)  NULL
4. Image                              IMAGE                    NULL
5. Date                               DATE                     NOT NULL
   
### 4. Vacancy
#### Поля:
1. Vacancy_Id      [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Name                               VARCHAR(max_length=20)   NOT NULL
3. Description                        VARCHAR(max_length=150)  NOT NULL
4. Need                               VARCHAR(max_length=20)   NOT NULL
   
### 5. About
#### Поля:
1. About_Id        [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Description                        VARCHAR(max_length=120)  NOT NULL
3. Video                              VARCHAR(max_length=120)  NULL
4. Image                              IMAGE                    NULL
5. History                            VARCHAR(max_length=120)  NULL
6. Details                            VARCHAR(max_length=120)  NULL
7. Certificate                        VARCHAR(max_length=220)  NULL
   
### 6. PromoCode
#### Поля:
1. Promo_Id        [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Code                               VARCHAR(max_length=20)   NOT NULL
3. Description                        VARCHAR(max_length=120)  NULL
4. Discount_Type                      VARCHAR(max_length=20)   NOT NULL
5. Discount_Value                     FLOAT                    NOT NULL
   
### 7. Client
#### Поля:
1. Client_Id       [PK]               INT                      NOT NULL AUTO_INCREMENT
2. User_Id         [FK: User]         INT                      NOT NULL                 (один ко многим)
3. First_Name                         VARCHAR(max_length=30)   NOT NULL
4. Last_Name                          VARCHAR(max_length=20)   NOT NULL
5. Patronymic                         VARCHAR(max_length=30)   NOT NULL
6. Notes                              VARCHAR(max_length=120)  NULL
7. Phone_Number                       VARCHAR(max_length=20)   NOT NULL
8. Has_Child                          TINYINT                  NOT NULL
   
### 8. Reservation
#### Поля:
1. Reservation_Id  [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Client_Id       [FK: Client]       INT                      NOT NULL                 (один ко многим)
3. Room_Id         [FK: Room]         INT                      NOT NULL                 (один ко многим)
4. Pay_Id          [FK: Res..Pay..]   INT                      NULL                     (один ко многим)
5. Arrival_Date                       DATE                     NOT NULL
6. Departure_Date                     DATE                     NOT NULL
7. Final_Price                        FLOAT                    NOT NULL
8. Created_At                         DATE                     NOT NULL
9. Notes                              VARCHAR(max_length=120)  NULL
   
### 9. User
#### Поля:
1. User_Id         [PK]               INT                      NOT NULL AUTO_INCREMENT
2. User_Name                          VARCHAR(max_length=50)   NOT NULL
3. Password                           VARCHAR(max_length=60)   NOT NULL
4. Age                                INT                      NOT NULL
6. Email                              VARCHAR(max_length=80)   NULL
   
### 10. CRUD
#### Поля:
1. CRUD_Id         [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Action_Id       [FK: Action]       INT                      NOT NULL                 (один ко многим)
3. Data_Id         [FK: Data]         INT                      NOT NULL                 (один ко многим)
4. Client_Id       [FK: Client]       INT                      NOT NULL                 (один ко многим)
5. Date                               DATE                     NOT NULL

### 11. Payment
#### Поля:
1. Payment_Id      [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Reservation_Id  [FK: Reservation]  INT                      NOT NULL                 (один к одному)
3. Amount                             FLOAT                    NOT NULL
4. Payment_Date                       DATE                     NOT NULL
   
### 12. Position
#### Поля:
1. Position_Id     [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Position_Name                      VARCHAR(max_length=20)   NOT NULL
   
### 13. EmployeePosition
#### Поля:
1. Position_Id     [FK: Position]     INT                      NULL                     (многие ко многим)
2. Employee_Id     [FK: Employee]     INT                      NULL                     (многие ко многим)
   
### 14. Action
#### Поля:
1. Action_Id       [PK]               INT                      NOT NULL AUTO_INCREMENT 
2. Name                               VARCHAR(max_length=20)   NOT NULL
   
### 15. Data
#### Поля:
1. Data_Id         [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Table_Name                         VARCHAR(max_length=20)   NOT NULL
   
### 16. ReservationPayment
#### Поля:
1. Pay_Id          [PK]               INT                      NOT NULL AUTO_INCREMENT
2. Payment_Id      [FK: Payment]      INT                      NOT NULL                 (один ко многим)
3. Reservation_Id  [FK: Reservation]  INT                      NOT NULL                 (один ко многим)
4. Timer                              DATE                     NOT NULL
5. Is_Completed                       TINYINT                  NOT NULL

### 17. Contact
#### Поля:
1. Contact_Id      [PK]               INT                      NOT NULL AUTO_INCREMENT
2. User_Id         [FK: User]         INT                      NOT NULL                 (один к одному)
3. First_Name                         VARCHAR(max_length=30)   NOT NULL
4. Last_Name                          VARCHAR(max_length=20)   NOT NULL
5. Patronymic                         VARCHAR(max_length=30)   NOT NULL
6. Description                        VARCHAR(max_length=120)  NULL
7. Photo                              VARCHAR(max_length=220)  NOT NULL
   
## Не нормализованная модель БД:
![Фин1](https://github.com/user-attachments/assets/e5ca5949-93e6-4082-8123-0d920dfeaa66)

## Даталогическая модель БД:
![Документ13](https://github.com/user-attachments/assets/5d17c3ee-486d-46f5-8adb-4b6b8ad349de)
