# ASPNET-Core-Angular-ReservationSystem
This project contains all the necessary code to reproduce ASPNET-Core-Angular-ReservationSystem using C# .NET CORE Web API 2.1 as REST API back-end service, MySQL as the main data storage and Angular 8 JavaScript framework. 

ASPNET-Core-Angular-ReservationSystem is an application which allows you to create reservations/events using Angular Boostrap Calendar interface and helps you make them available in the calendar through PayPal API payment method. 

![reservation_system](https://user-images.githubusercontent.com/11573356/64649310-ee146e80-d41c-11e9-81be-68d68281e275.gif)


Technologies:
```
- .NET CORE Web API 2.1
- MySQL
- Angular 8
- Bootstrap 4+
- Angular Bootstrap Calendar 6+ library
- Ngui Datetime Picker library
- ngx-toastr notifications libray
```

Core Functionalities:
```
- Login & Register using JWT (JSON Web Token) authentication
- Input Validations (Login & Register)
- Create, Update & Delete temporary reservation
- Enable 'Reserve Now' button on creation of temporary reservation
- Input Validations Datetime Picker (Time selection)
- Integration Payment Method: PayPal API
- My Reservations Feature
- Reservation Details
- Create reservations 1+ days
- Search reservations by title / reservation name
- Mobile friendly
```

Basic project installation steps:
```
Clone repository

BACK-END:
1. navigate to back-end project
   cd back-end
   
2. dotnet restore

3. navigate to back-end/appsettings.json and replace connection string with you own
   "ConnectionStrings": {
        "DefaultConnection": "server=localhost;port=3306;user=root;password=password;database=reservationDB"
   }
   
4. create migration file
   dotnet ef migrations add FirstMigration

5. update database
   dotnet ef database update FirstMigration
   
6. open MySQL workbench

7. navigate to reservationDB database

8. perform SQL insertion for the following Field and FieldDetails data

INSERT INTO `reservationDB`.`Field` (`FieldID`, `Title`, `ImageURL`, `PriceHour`, `PathURL`)
VALUES (100, 'Outdoor Tennis', '../../../assets/img/tennis.jpg', 150, 'outdoor-tennis'),
 (101, 'Artificial Football Outdoor', '../../../assets/img/artificial-football.jpg', 120, 'artificial-football-outdoor'),
 (102, 'Outdoor Basketball', '../../../assets/img/basketball.jpg', 75, 'outdoor-basketball'),
 (103, 'Futsal', '../../../assets/img/futsal.jpg', 85, 'futsal'),
 (104, 'Table Tennis', '../../../assets/img/table-tennis.jpg', 60, 'table-tennis'),
 (105, 'Handball', '../../../assets/img/handball.jpg', 100, 'handball'),
 (106, 'Volleyball', '../../../assets/img/volleyball.jpg', 90, 'volleyball'),
 (107, 'Badminton', '../../../assets/img/badminton.jpg', 85, 'badminton');

INSERT INTO `reservationDB`.`FieldDetail` (`FieldID`, `Description`, `Address`, `StartProgram`, `EndProgram`)
VALUES
(100, 'A tennis court is the venue where the sport of tennis is played. It is a firm rectangular surface with a low net stretched across the center. The same surface can be used to play both doubles and singles matches. A variety of surfaces can be used to create a tennis court, each with its own characteristics which affect the playing style of the game. ', 'Lindholm 88, Odense, Denmark', '10', '22'),
(101, 'A football pitch (also known as a football field[1] or soccer field) is the playing surface for the game of association football. Its dimensions and markings are defined by Law 1 of the Laws of the Game, "The Field of Play". The pitch is typically made of natural turf or artificial turf, although amateur and recreational teams often play on dirt fields. Artificial surfaces must be green in colour. ', 'Algade 75, Copenhagen, Denmark', '9', '18'),
(102, 'Basketball is a team sport in which two teams, most commonly of five players each, opposing one another on a rectangular court, compete with the primary objective of shooting a basketball (approximately 9.4 inches (24 cm) in diameter) through the defenders hoop', 'Brondby 91, Denmark', '11', '21'),
(103, 'Futsal (also known as fútsal or footsal) is a variant of association football played on a hard court, smaller than a football pitch, and mainly indoors. It features similarities to five-a-side football. ', 'Aagade 51, Aalborg, Denmark', '12', '19'),
(104, 'Table tennis, also known as ping-pong, is a sport in which two or four players hit a lightweight ball back and forth across a table using small rackets. The game takes place on a hard table divided by a net. ', 'Danebrosgade, 1-7, Aarhus, Denmark', '10', '18'),
(105, 'Handball (also known as team handball, European handball or Olympic handball) is a team sport in which two teams of seven players each (six outcourt players and a goalkeeper) pass a ball using their hands with the aim of throwing it into the goal of the other team.', 'Casper 77, Aalborg, Denmark', '13', '21'),
(106, 'Volleyball is a popular team sport in which two teams of six players are separated by a net. Each team tries to score points by grounding a ball on the other teams court under organized rules.', 'Ryesgade 67, Copenhagen, Denmark', '10', '19'),
(107, 'Badminton is a racquet sport played using racquets to hit a shuttlecock across a net. Although it may be played with larger teams, the most common forms of the game are "singles" (with one player per side) and "doubles" (with two players per side).', 'Sofiendelsvej 99, Aalborg, Denmark', '9', '20');

9. create PayPal sandbox account

10. create buyer mock & business mock test account to perform PayPal payments
      
FRONT-END:
1. cd front-end/reservation-system
2. navigate to index.html file
3. replace client-id
   <script src="https://www.paypal.com/sdk/js?client-id=REPLACE_WITH_YOUR_CLIENT_ID&currency=DKK"></script>
2. npm install
3. ng build
5. ng serve
6. access locahost:4200 in browser

```
Database Schema: 
![reservationDB](https://user-images.githubusercontent.com/11573356/64649407-1734ff00-d41d-11e9-95cb-53fe2c2aa2a6.png)
