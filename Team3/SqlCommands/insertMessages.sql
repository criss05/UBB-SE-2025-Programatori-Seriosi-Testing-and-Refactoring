CREATE TABLE messages(
	message_id int identity(1,1) primary key,
	content varchar(100),
	userId int,
	chatId int
)

INSERT INTO messages (content, userId, chatId) VALUES ('Hello, how are you?', 101, 1);
INSERT INTO messages (content, userId, chatId) VALUES ('I am doing great, thanks!', 102, 1);
INSERT INTO messages (content, userId, chatId) VALUES ('What are your plans for the weekend?', 101, 1);
INSERT INTO messages (content, userId, chatId) VALUES ('I am thinking of going hiking.', 102, 1);
INSERT INTO messages (content, userId, chatId) VALUES ('That sounds fun! Enjoy!', 101, 1);