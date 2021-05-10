const TeleBot = require('telebot');
const secrets = require('./secrets.json');
const bot = new TeleBot(secrets.BOT_TOKEN);
const Commands = require('./lib/Commands');
const cmd = new Commands(bot);
const Fetch = require('./lib/Fetch');
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0

bot.on('text', async (msg) => {
  const msgCmd = msg.text.substring(1)
  const msgArray = msgCmd.split(' ');
  let botInfos = await bot.getMe();
  let test = msgArray[0];
  var commandArray = msgArray[0].split('@')
  var cmdName = commandArray[0]
  var msgBotName = commandArray[1]

  new RegExp(`(^\/${cmdName})(@${botInfos.username})?$`).test(msg.text) && typeof cmd[cmdName] === "function" ? cmd[cmdName](msg) : errorCmd(msg);
});

function errorCmd(msg) {
  msg.reply.text("Commande introuvable...")
}

bot.start();
