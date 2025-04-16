CREATE TABLE messages(
	message_id int identity(1,1) primary key,
	content varchar(100),
	userId int,
	chatId int,
	sentDateTime datetime
)

INSERT INTO messages (content, userId, chatId, sentDateTime) VALUES ('Hello, how are you?', 101, 1, '2025-04-13 11:13:25');
INSERT INTO messages (content, userId, chatId, sentDateTime) VALUES ('I am doing great, thanks!', 102, 1, '2025-04-14 20:30:59');
INSERT INTO messages (content, userId, chatId, sentDateTime) VALUES ('What are your plans for the weekend?', 101, 1, '2025-04-12 16:30:00');
INSERT INTO messages (content, userId, chatId, sentDateTime) VALUES ('I am thinking of going hiking.', 102, 1, '2025-04-15 23:59:59');
INSERT INTO messages (content, userId, chatId, sentDateTime) VALUES ('That sounds fun! Enjoy!', 101, 1, '2025-03-08 08:08:08');