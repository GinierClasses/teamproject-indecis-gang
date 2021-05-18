const TeleBot = require('telebot');
const secrets = require('./secrets.json');
const bot = new TeleBot(secrets.BOT_TOKEN);
const Commands = require('./lib/Commands');
const cmd = new Commands(bot);
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0

bot.on('text', async (msg) => {
    let botInfos = await bot.getMe();
    let msgArray = msg.text.substring(1).split(' ')
    let cmdName = msgArray[0].split('@')[0].toLowerCase()
    msg.props = msgArray
    new RegExp(`(^${cmdName})(@${botInfos.username})?$`).test(msgArray[0].toLowerCase()) && typeof cmd[cmdName] === "function" ? cmd[cmdName](msg) : cmd.errorCmd(msg);
});

bot.start();
