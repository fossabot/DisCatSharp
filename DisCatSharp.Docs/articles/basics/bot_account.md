---
uid: basics_bot_account
title: Creating a Bot Account
---

# Creating a Bot Account

## Create an Application
Before you're able to create a [bot account](https://discord.com/developers/docs/topics/oauth2#bots) to interact with the Discord API, you'll need to create a new OAuth2 application.
Go to the [Discord Developer Portal](https://discord.com/developers/applications) and click `New Application` at the top right of the page.

![Discord Developer Portal](/images/basics_bot_account_01.png)

<br/>
You'll then be prompted to enter a name for your application.<br/>

![Naming Application](/images/basics_bot_account_02.png "Naming Application")

The name of your application will be the name displayed to users when they add your bot to their Discord server.<br/>
With that in mind, it would be a good idea for your application name to match the desired name of your bot.

Enter your desired application name into the text box, accept the [Developer Terms of Service](https://discord.com/developers/docs/policies-and-agreements/terms-of-service) and [Developer Policy](https://discord.com/developers/docs/policies-and-agreements/developer-policy) and hit the `Create` button.

After you hit `Create`, you'll be taken to the application page for your newly created application.

![Application Page](/images/basics_bot_account_03.png)

That was easy, wasn't it?

Before you move on, you may want to upload an icon for your application and provide a short description of what your bot will do.
As with the name of your application, the application icon and description will be displayed to users when adding your bot.


## Add a Bot Account
Now that you have an application created, you'll be able to add a brand new bot account to it.

Head on over to the bot page of your application by clicking on `Bot` in the left panel.<br/>
From there, click on the `Add Bot` button at the top right of the page.

![Bot Page](/images/basics_bot_account_04.png)

Then confirm the creation of the bot account.

![Creation Confirmation](/images/basics_bot_account_05.png)


# Using Your Bot Account

## Invite Your Bot
Now that you have a bot account, you'll probably want to invite it to a server!

A bot account joins a server through a special invite link that'll take users through the OAuth2 flow;
you'll probably be familiar with this if you've ever added a public Discord bot to a server.
To get the invite link for your bot, head on over to the `OAuth2` page of your application and select the `URL Generator` page.

![OAuth2 URL Generator](/images/basics_bot_account_06.png "OAuth2 URL Generator")

<br/>
We'll be using the *OAuth2 URL Generator* on this page.<br/>
Simply tick `bot` under the *scopes* panel; your bot invite link will be generated directly below.

![OAuth2 Scopes](/images/basics_bot_account_07.png "OAuth2 Scopes")

<br/>
By default, the generated link will not grant any permissions to your bot when it joins a new server.<br/>
If your bot requires specific permissions to function, you'd select them in the *bot permissions* panel.

![Permissions](/images/basics_bot_account_08.png "Permissions Panel")

The invite link in the *scopes* panel will update each time you change the permissions.<br/>
Be sure to copy it again after any changes!

## Get Bot Token
Instead of logging in to Discord with a username and password, bot accounts use a long string called a *token* to authenticate.
You'll want to retrieve the token for your bot account so you can use it with DisCatSharp.

Head back to the bot page and click on `Reset Token` just below the bot's username field.

![Token Reset](/images/basics_bot_account_09.png "Token Reset")

Click on `Yes, do it!` to confirm the reset.

![Token Reset Confirm](/images/basics_bot_account_10.png "Token Reset Confirmation")

Go ahead and copy your bot token and save it somewhere. You'll be using it soon!

>[!IMPORTANT]
 > Handle your bot token with care! Anyone who has your token will have access to your bot account.
 > Be sure to store it in a secure location and *never* give it to *anybody*.
 >
 > If you ever believe your token has been compromised, be sure to hit the `Reset Token` button (as seen above) to invalidate your old token and get a brand new token.

## Write Some Code
You've got a bot account set up and a token ready for use.<br/>
Sounds like it's time for you to [write your first bot](xref:basics_first_bot)!
