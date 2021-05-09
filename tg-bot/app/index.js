const TeleBot = require('telebot');
const secrets = require('./secrets.json');
const bot = new TeleBot(secrets.BOT_TOKEN);
var notification = true;

bot.on('/bonjour', function(msg) { 
    console.log(msg);
    return msg.reply.text(`Bonjour ${msg.from.username}`);
});

bot.on('/bonsoir', function(msg) { 
    console.log(msg);
    return msg.reply.text(`Bonsoir ${msg.from.username}`);
});

bot.on('/notification', function(msg) {
    notification = notification == true ? false : true;
    console.log(notification);
    return notification ? msg.reply.text("Les notifications ont été activées !") : msg.reply.text("Les notifications ont été désactivées !");
});

bot.start();