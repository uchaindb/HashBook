using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashBook
{
    class Program
    {
        static string sentences = @"You can do anything, but not everything.
Perfection is achieved, not when there is nothing more to add, but when there is nothing left to take away.
The richest man is not he who has the most, but he who needs the least.
You miss 100 percent of the shots you never take.
Courage is not the absence of fear, but rather the judgement that something else is more important than fear.
You must be the change you wish to see in the world.
When hungry, eat your rice; when tired, close your eyes. Fools may laugh at me, but wise men will know what I mean.
The third-rate mind is only happy when it is thinking with the majority. The second-rate mind is only happy when it is thinking with the minority. The first-rate mind is only happy when it is thinking.
To the man who only has a hammer, everything he encounters begins to look like a nail.
We are what we repeatedly do; excellence, then, is not an act but a habit.
A wise man gets more use from his enemies than a fool from his friends.
Do not seek to follow in the footsteps of the men of old; seek what they sought.
Watch your thoughts; they become words.
Watch your words; they become actions.
Watch your actions; they become habits.
Watch your habits; they become character.
Watch your character; it becomes your destiny.
Everyone is a genius at least once a year. The real geniuses simply have their bright ideas closer together.
What we think, or what we know, or what we believe is, in the end, of little consequence. The only consequence is what we do.
The real voyage of discovery consists not in seeking new lands but seeing with new eyes.
Work like you don’t need money, love like you’ve never been hurt, and dance like no one’s watching
Try a thing you haven’t done three times. Once, to get over the fear of doing it. Twice, to learn how to do it. And a third time, to figure out whether you like it or not.
Even if you’re on the right track, you’ll get run over if you just sit there.
People often say that motivation doesn’t last. Well, neither does bathing – that’s why we recommend it daily.
re I got married I had six theories about bringing up children; now I have six children and no theories.
What the world needs is more geniuses with humility, there are so few of us left.
Always forgive your enemies; nothing annoys them so much.
I’ve gone into hundreds of [fortune-teller’s parlors], and have been told thousands of things, but nobody ever told me I was a policewoman getting ready to arrest her.
When you go into court you are putting your fate into the hands of twelve people who weren’t smart enough to get out of jury duty.
Those who believe in telekinetics, raise my hand.
Just the fact that some geniuses were laughed at does not imply that all who are laughed at are geniuses. They laughed at Columbus, they laughed at Fulton, they laughed at the Wright brothers. But they also laughed at Bozo the Clown.
My pessimism extends to the point of even suspecting the sincerity of the pessimists.
Sometimes I worry about being a success in a mediocre world.
I quit therapy because my analyst was trying to help me behind my back.
We’ve heard that a million monkeys at a million keyboards could produce the complete works of Shakespeare; now, thanks to the Internet, we know that is not true.
If there are no stupid questions, then what kind of questions do stupid people ask? Do they get smart just in time to ask questions?
If the lessons of history teach us anything it is that nobody learns the lessons that history teaches us.
When I was a boy I was told that anybody could become President. Now I’m beginning to believe it.
Laughing at our mistakes can lengthen our own life. Laughing at someone else’s can shorten it.
There are many who dare not kill themselves for fear of what the neighbors will say.
There’s so much comedy on television. Does that cause comedy in the streets?
All men are frauds. The only difference between them is that some admit it. I myself deny it.
I don’t mind what Congress does, as long as they don’t do it in the streets and frighten the horses.
I took a speed reading course and read ‘War and Peace’ in twenty minutes. It involves Russia.
The person who reads too much and uses his brain too little will fall into lazy habits of thinking.
Believe those who are seeking the truth. Doubt those who find it.
It is the mark of an educated mind to be able to entertain a thought without accepting it.
I’d rather live with a good question than a bad answer.
We learn something every day, and lots of times it’s that what we learned the day before was wrong.
I have made this letter longer than usual because I lack the time to make it shorter.
Don’t ever wrestle with a pig. You’ll both get dirty, but the pig will enjoy it.
An inventor is simply a fellow who doesn’t take his education too seriously.
Asking a working writer what he thinks about critics is like asking a lamppost how it feels about dogs.
Better to write for yourself and have no public, than to write for the public and have no self.
Never be afraid to laugh at yourself, after all, you could be missing out on the joke of the century.
I am patient with stupidity but not with those who are proud of it.
Normal is getting dressed in clothes that you buy for work and driving through traffic in a car that you are still paying for – in order to get to the job you need to pay for the clothes and the car, and the house you leave vacant all day so you can afford to live in it.
The cure for boredom is curiosity. There is no cure for curiosity.
Advice is what we ask for when we already know the answer but wish we didn’t.
Some people like my advice so much that they frame it upon the wall instead of using it.
The trouble with the rat race is that even if you win, you’re still a rat.
Never ascribe to malice, that which can be explained by incompetence.
Imagination was given to man to compensate him for what he is not, and a sense of humor was provided to console him for what he is.
When a person can no longer laugh at himself, it is time for others to laugh at him.
";
        static void Main(string[] args)
        {
            //string source = "Hello World!";
            //string hash = CreateMD5(source);
            //Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

            var sb = new StringBuilder();
            sb.AppendLine("<style>" +
                " body { font-family: monospace; max-width: 500px; }" +
                " .md5 { color: green }" +
                " .input { color: blue; margin-left: 15px; }" +
                //"table { font-family: monospace; }" +
                //" table td:nth-child(1) {color: green;}" +
                //" table td:nth-child(2) {color: blue;}" +
                "</style>");
            //sb.AppendLine("<table>");
            sb.AppendLine("<div>");

            var sens = sentences
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(_ => _);
            foreach (var sentence in sens)
            {
                sb.Append(Pair(sentence));
            }

            for (int i = 0; i < 10000; i++)
            {
                sb.Append(Pair(i.ToString()));
            }

            for (int i = 0; i < 256; i++)
            {
                sb.Append(Pair(Convert.ToString(i, 2)));
            }

            //sb.AppendLine("</table>");
            sb.AppendLine("</div>");
            File.WriteAllText("output.html", sb.ToString());
        }
        public static string Pair(string input)
        {
            //return $"<tr><td>{input}</td><td>{CreateMD5(input)}</td></tr>";
            return $"<span class=\"md5\">{CreateMD5(input)}</span>" +
                $"<span class=\"input\">{input}</span>" +
                $"<br />";
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
