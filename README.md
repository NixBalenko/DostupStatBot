# DostupStatBot

DostupStatBot is a Telegram bot developed using .NET 8, deployed as an AWS Lambda function, with a console application for local debugging. This project allows you to interact with your bot seamlessly both locally and on the AWS cloud.

## Table of Contents
- [Getting Started](#getting-started)
- [Local Development](#local-development)
- [Deploying to AWS Lambda](#deploying-to-aws-lambda)
- [License](#license)

## Getting Started

Follow these instructions to set up and run the bot both locally and on AWS Lambda.

### Local Development

To run the bot locally, follow these steps:

1. **Create a New Bot**
   - Go to [BotFather](https://t.me/botfather) on Telegram and create a new bot.

2. **Generate Token**
   - After creating the bot, BotFather will provide you with a bot token.

3. **Add Token as Environment Variable**
   - Set the environment variable `DostupStatBot_BotToken` with your bot token.

4. **Start Console App**
   - Open your console application in your preferred IDE or terminal.

5. **Test the Bot**
   - Type `/help` in your new bot chat to see the available commands and ensure everything is working.

### Deploying to AWS Lambda

To deploy the bot as an AWS Lambda function, follow these steps:

1. **Create a New Bot**
   - As above, create a new bot using BotFather.

2. **Generate Token**
   - Obtain your bot token from BotFather.

3. **Deploy AWS Lambda**
   - Package your .NET 8 application and deploy it to AWS Lambda.

4. **Add Token as Lambda Environment Variable**
   - In your AWS Lambda function configuration, set the environment variable `DostupStatBot_BotToken` with your bot token.

5. **Configure AWS API Gateway**
   - Create a new API in AWS API Gateway that connects to your Lambda function.
   - Set it up to handle POST requests.

6. **Configure Webhook**
   - Execute the following request in your browser to set the webhook:
 `https://api.telegram.org/bot<your token>/setWebhook?url=<URL to your API Gateway resource>`

 - Replace `<your token>` with your actual bot token and `<URL to your API Gateway resource>` with the endpoint URL of your API Gateway.

7. **Test the Bot**
   - Type `/help` in your new bot chat to see the available commands and ensure everything is working.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
