const TeleBot = require('telebot');
const secrets = require('./secrets.json');
const bot = new TeleBot(secrets.BOT_TOKEN);
var notification = true;

bot.on('/bonjour', (msg) => msg.reply.text(`Bonjour ${msg.from.username}`));

bot.on('/bonsoir', (msg) => msg.reply.text(`Bonsoir ${msg.from.username}`));

bot.on('/notification', function(msg) {
    notification = notification == true ? false : true;
    return notification ? msg.reply.text("Les notifications ont été activées !") : msg.reply.text("Les notifications ont été désactivées !");
});

bot.start();