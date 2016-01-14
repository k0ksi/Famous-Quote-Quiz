namespace QuoteQuiz.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class QuoteQuizConfiguration 
        : DbMigrationsConfiguration<QuoteQuizDbContext>
    {
        public QuoteQuizConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "QuoteQuiz.Data.QuoteQuizDbContext";
        }

        protected override void Seed(QuoteQuizDbContext context)
        {
            if (!context.Quotes.Any())
            {
                var people = this.LoadPeople(context);
                var quotes = this.LoadQuotes(context);
            }
        }

        private IEnumerable<Person> LoadPeople(IQuoteQuizDbContext context)
        {
            var famousPeople = new List<Person>()
            {
                new Person()
                {
                    Name = "Albert Einstein"
                },
                new Person()
                {
                    Name = "Mark Twain"
                },
                new Person()
                {
                    Name = "John Lennon"
                },
                new Person()
                {
                    Name = "Buddha"
                },
                new Person()
                {
                    Name = "Woody Allen"
                },
                new Person()
                {
                    Name = "Steve Jobs"
                },
                new Person()
                {
                    Name = "Pablo Picasso"
                },
                new Person()
                {
                    Name = "Christopher Columbus"
                },
                new Person()
                {
                    Name = "Socrates"
                },
                new Person()
                {
                    Name = "Michael Jordan"
                },
                new Person()
                {
                    Name = "Amelia Earhart"
                },
                new Person()
                {
                    Name = "Henry Ford"
                },
                new Person()
                {
                    Name = "Winston Churchill"
                },
                new Person()
                {
                    Name = "William Shakespeare"
                }
            };

            foreach (var person in famousPeople)
            {
                context.People.Add(person);
            }

            context.SaveChanges();

            return famousPeople;
        }

        private IEnumerable<Quote> LoadQuotes(IQuoteQuizDbContext context)
        {
            var williamShakespeareId = context.People
                .FirstOrDefault(p => p.Name == "William Shakespeare").Id;
            var winstonChurcillId = context.People
                .FirstOrDefault(p => p.Name == "Winston Churchill").Id;
            var henryFordId = context.People
                .FirstOrDefault(p => p.Name == "Henry Ford").Id;
            var albertEinsteinId = context.People
                .FirstOrDefault(p => p.Name == "Albert Einstein").Id;
            var markTwainId = context.People
                .FirstOrDefault(p => p.Name == "Mark Twain").Id;
            var johnLennonId = context.People
                .FirstOrDefault(p => p.Name == "John Lennon").Id;
            var buddhaId = context.People
                .FirstOrDefault(p => p.Name == "Buddha").Id;
            var woodyAllanId = context.People
                .FirstOrDefault(p => p.Name == "Woody Allen").Id;
            var steveJobsId = context.People
                .FirstOrDefault(p => p.Name == "Steve Jobs").Id;
            var pabloPicassoId = context.People
                .FirstOrDefault(p => p.Name == "Pablo Picasso").Id;
            var christopherColumbusId = context.People
                .FirstOrDefault(p => p.Name == "Christopher Columbus").Id;
            var socratesId = context.People
                .FirstOrDefault(p => p.Name == "Socrates").Id;
            var michaelJordanId = context.People
                .FirstOrDefault(p => p.Name == "Michael Jordan").Id;
            var amelieEarhartId = context.People
                .FirstOrDefault(p => p.Name == "Amelia Earhart").Id;

            var quotes = new List<Quote>()
            {
                new Quote()
                {
                    Text = "If we knew what it was we were doing, it would not be called research, would it?",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Strive not to be a success, but rather to be of value.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Science without religion is lame, religion without science is blind.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "A clever person solves a problem. A wise person avoids it.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Never memorize something that you can look up.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "When you are courting a nice girl an hour seems like a second. When you sit on a red-hot cinder a second seems like an hour. That's relativity.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "I speak to everyone in the same way, whether he is the garbage man or the president of the university.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Anyone who has never made a mistake has never tried anything new.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Life is like riding a bicycle. To keep your balance, you must keep moving.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Logic will get you from A to Z; imagination will get you everywhere.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "If you want your children to be intelligent, read them fairy tales. If you want them to be more intelligent, read them more fairy tales.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "If you can't explain it to a six year old, you don't understand it yourself.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "I am enough of an artist to draw freely upon my imagination. Imagination is more important than knowledge. Knowledge is limited. Imagination encircles the world.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "There are only two ways to live your life. One is as though nothing is a miracle. The other is as though everything is a miracle.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.",
                    PersonId = albertEinsteinId
                },
                new Quote()
                {
                    Text = "I’ve missed more than 9000 shots in my career. I’ve lost almost 300 games. 26 times I’ve been trusted to take the game winning shot and missed. I’ve failed over and over and over again in my life. And that is why I succeed.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "If you quit ONCE it becomes a habit.Never quit!!!",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "I've never lost a game I just ran out of time.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "To be successful you have to be selfish, or else you never achieve. And once you get to your highest level, then you have to be unselfish. Stay reachable. Stay in touch. Don't isolate.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "You must expect great things of yourself before you can do them.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "My attitude is that if you push me towards something that you think is a weakness, then I will turn that perceived weakness into a strength.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "Some people want it to happen, some wish it would happen, and others make it happen.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "I can accept failure, everyone fails at something. But I can't accept not trying.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "Talent wins games, but teamwork and intelligence wins championships.",
                    PersonId = michaelJordanId
                },
                new Quote()
                {
                    Text = "The most difficult thing is the decision to act, the rest is merely tenacity.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "Some of us have great runways already built for us. If you have one, take off. But if you don't have one, realize it is your responsibility to grab a shovel and build one for yourself and for those who will follow after you.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "...decide...whether or not the goal is worth the risks involved. If it is, stop worrying....",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "I did for the fun of it",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "The most effective way to do it is to do it.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "Being alone is scary, but not as scary as feeling alone in a relationship.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "Courage is the price that life exacts for granting peace.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "Never interrupt someone doing something you said couldn't be done.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "I want to do it because I want to do it. Women must try to do things as men have tried. When they fail, their failure must be but a challenge to others.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "Adventure is worthwhile in itself.",
                    PersonId = amelieEarhartId
                },
                new Quote()
                {
                    Text = "Life is what happens to you while you’re busy making other plans.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "If everyone demanded peace instead of another television set, then there'd be peace.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "There's nowhere you can be that isn't where you're meant to be...",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "One thing you can't hide - is when you're crippled inside.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "A dream you dream alone is only a dream. A dream you dream together is reality.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "The more I see, the less I know for sure.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "As usual, there is a great woman behind every idiot.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "I believe in everything until it's disproved. So I believe in fairies, the myths, dragons. It all exists, even if it's in your mind. Who's to say that dreams and nightmares aren't as real as the here and now?",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "You may say I'm a dreamer, but I'm not the only one. I hope someday you'll join us. And the world will live as one.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "Count your age by friends, not years. Count your life by smiles, not tears.",
                    PersonId = johnLennonId
                },
                new Quote()
                {
                    Text = "Twenty years from now you will be more disappointed by the things that you didn’t do than by the ones you did do, so throw off the bowlines, sail away from safe harbor, catch the trade winds in your sails.  Explore, Dream, Discover.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "Never tell the truth to people who are not worthy of it.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "The fear of death follows from the fear of life. A man who lives fully is prepared to die at any time.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "A lie can travel half way around the world while the truth is putting on its shoes.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "Classic' - a book which people praise and don't read.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "I have never let my schooling interfere with my education.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "Never put off till tomorrow what may be done day after tomorrow just as well.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "The man who does not read has no advantage over the man who cannot read.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "Good friends, good books, and a sleepy conscience: this is the ideal life.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "Whenever you find yourself on the side of the majority, it is time to reform (or pause and reflect).",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "If you tell the truth, you don't have to remember anything.",
                    PersonId = markTwainId
                },
                new Quote()
                {
                    Text = "The mind is everything. What you think you become.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "Health is the greatest gift, contentment the greatest wealth, faithfulness the best relationship.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "What we think, we become.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "To keep the body in good health is a duty... otherwise we shall not be able to keep our mind strong and clear.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "Better than a thousand hollow words, is one word that brings peace.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "Three things cannot be long hidden: the sun, the moon, and the truth.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "We are shaped by our thoughts; we become what we think. When the mind is pure, joy follows like a shadow that never leaves.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "No one saves us but ourselves. No one can and no one may. We ourselves must walk the path.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "Health is the greatest gift, contentment the greatest wealth, faithfulness the best relationship",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "Do not dwell in the past, do not dream of the future, concentrate the mind on the present moment.",
                    PersonId = buddhaId
                },
                new Quote()
                {
                    Text = "An unexamined life is not worth living.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "By all means marry; if you get a good wife, you’ll become happy; if you get a bad one, you’ll become a philosopher.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "Education is the kindling of a flame, not the filling of a vessel.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "Strong minds discuss ideas, average minds discuss events, weak minds discuss people.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "To find yourself, think for yourself.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "Be kind, for everyone you meet is fighting a hard battle.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "Wonder is the beginning of wisdom.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "I cannot teach anybody anything. I can only make them think.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "There is only one good, knowledge, and one evil, ignorance.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "The only true wisdom is in knowing you know nothing.",
                    PersonId = socratesId
                },
                new Quote()
                {
                    Text = "Your time is limited, so don’t waste it living someone else’s life.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "Design is not just what it looks like and feels like. Design is how it works.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "Creativity is just connecting things. When you ask creative people how they did something, they feel a little guilty because they didn’t really do it, they just saw something. It seemed obvious to them after a while.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "When you’re a carpenter making a beautiful chest of drawers, you’re not going to use a piece of plywood on the back, even though it faces the wall and nobody will see it. You’ll know it’s there, so you’re going to use a beautiful piece of wood on the back. For you to sleep well at night, the aesthetic, the quality, has to be carried all the way through.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "Sometimes when you innovate, you make mistakes. It is best to admit them quickly, and get on with improving your other innovations.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "Innovation distinguishes between a leader and a follower.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "Quality is much better than quantity. One home run is much better than two doubles.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "I think if you do something and it turns out pretty good, then you should go do something else wonderful, not dwell on it for too long. Just figure out what’s next.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "That’s been one of my mantras — focus and simplicity. Simple can be harder than complex; you have to work hard to get your thinking clean to make it simple.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "We don’t get a chance to do that many things, and every one should be really excellent. Because this is our life. Life is brief, and then you die, you know? And we’ve all chosen to do this with our lives. So it better be damn good. It better be worth it.",
                    PersonId = steveJobsId
                },
                new Quote()
                {
                    Text = "Every child is an artist. The problem is how to remain an artist once he grows up.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Colors, like features, follow the changes of the emotions.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Art is not the application of a canon of beauty but what the instinct and the brain can conceive beyond any canon. When we love a woman we don't start measuring her limbs.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "An idea is a point of departure and no more. As soon as you elaborate it, it becomes transformed by thought.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Action is the foundational key to all success.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Art washes away from the soul the dust of everyday life.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Art is the elimination of the unnecessary.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Everything you can imagine is real.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "I do not seek. I find.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Every act of creation is first an act of destruction.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "Bad artists copy. Good artists steal.",
                    PersonId = pabloPicassoId
                },
                new Quote()
                {
                    Text = "You can never cross the ocean until you have the courage to lose sight of the shore.",
                    PersonId = christopherColumbusId
                },
                new Quote()
                {
                    Text = "The sea will grant each man new hope. The sleep brings dreams of home.",
                    PersonId = christopherColumbusId
                },
                new Quote()
                {
                    Text = "The world is round.",
                    PersonId = christopherColumbusId
                },
                new Quote()
                {
                    Text = "So tractable, so peaceable are these people that I swear to your Majesties there is not in the world a better nation. They love their neighbors as themselves, and their discourse is ever sweet and gentle and accompanied with a smile; and though it is true that they are naked, yet their manners are decorous and praiseworthy.",
                    PersonId = christopherColumbusId
                },
                new Quote()
                {
                    Text = "Following the light of the sun, we left the Old World.",
                    PersonId = christopherColumbusId
                },
                new Quote()
                {
                    Text = "Eighty percent of success is showing up.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "Tradition is the illusion of permanance.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "The talent for being happy is appreciating and liking what you have, instead of what you don't have.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "Sex without love is a meaningless experience, but as far as meaningless experiences go its pretty damn good.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "I failed to make the chess team because of my height.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "I'm not afraid of death; I just don't want to be there when it happens.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "I don't know the question, but sex is definitely the answer.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "Life doesn't imitate art, it imitates bad television.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "The difference between sex and love is that sex relieves tension and love causes it.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "To you, I'm an atheist. To God, I'm the loyal opposition.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "Is sex dirty? Only when it's being done right.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "If you want to make God laugh, tell him about your plans.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "God is silent. Now if only man would shut up.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "My one regret in life is that I am not someone else.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "I'm not anti-social. I'm just not social.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "It's a match made in heaven...by a retarded angel.",
                    PersonId = woodyAllanId
                },
                new Quote()
                {
                    Text = "Coming together is the beginning. Keeping together is progress. Working together is success.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Quality means doing it right when no one is looking.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Most people spend more time and energy going around problems than in trying to solve them.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Nothing is particularly hard if you divide it into small jobs.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Chop your own wood and it will warm you twice.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "It has been my observation that most people get ahead during the time that others waste.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "When everything seem to be going against you, remember that the airplane takes off against the wind, not with it ....",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Thinking is the hardest work there is, which is probably the reason so few engage in it.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Vision without execution is just hallucination.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "The man who thinks he can and the man who thinks he can't are both right. Which one are you?",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "If I had asked people what they wanted, they would have said faster horses.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Obstacles are those frightful things you see when you take your eyes off your goals.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "The only real mistake is the one from which we learn nothing.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Don't find fault, find a remedy; anybody can complain",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "My best friend is the one who brings out the best in me.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "You can't build a reputation on what you are going to do.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Failure is simply an opportunity to begin again, this time more intelligently.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Anyone who stops learning is old, whether at twenty or eighty. Anyone who keeps learning stays young.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "Whether you think you can, or you think you can't--you're right.",
                    PersonId = henryFordId
                },
                new Quote()
                {
                    Text = "A pessimist sees the difficulty in every opportunity; an optimist sees the opportunity in every difficulty.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "You have enemies? Good. That means you've stood up for something, sometime in your life.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Courage is what it takes to stand up and speak; courage is also what it takes to sit down and listen.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Men occasionally stumble over the truth, but most of them pick themselves up and hurry off as if nothing ever happened.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "My tastes are simple: I am easily satisfied with the best.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "If you are going through hell, keep going.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "A lie gets halfway around the world before the truth has a chance to get its pants on.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "History will be kind to me for I intend to write it.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Tact is the ability to tell someone to go to hell in such a way that they look forward to the trip.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Success is stumbling from failure to failure with no loss of enthusiasm.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Never, never, never give in!",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Success is not final, failure is not fatal: it is the courage to continue that counts.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "I am fond of pigs. Dogs look up to us. Cats look down on us. Pigs treat us as equals.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Nothing in life is so exhilarating as to be shot at without result.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "It is not enough that we do our best; sometimes we must do what is required.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "A lady came up to me one day and said 'Sir! You are drunk', to which I replied 'I am drunk today madam, and tomorrow I shall be sober but you will still be ugly.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "Kites rise highest against the wind, not with it.",
                    PersonId = winstonChurcillId
                },
                new Quote()
                {
                    Text = "The fool doth think he is wise, but the wise man knows himself to be a fool.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "I like this place and could willingly waste my time in it.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Stars, hide your fires; Let not light see my black and deep desires.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Dispute not with her: she is lunatic.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Don't waste your love on somebody, who doesn't value it.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "thus with a kiss I die",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Double, double, toil and trouble; Fire burn, and cauldron bubble!",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "The course of true love never did run smooth.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Lord, what fools these mortals be!",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Though she be but little, she is fierce!",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "My tongue will tell the anger of my heart, or else my heart concealing it will break.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "You speak an infinite deal of nothing.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "We know what we are, but not what we may be.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Words are easy, like the wind; Faithful friends are hard to find.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Hell is empty and all the devils are here.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "There is nothing either good or bad, but thinking makes it so.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "It is not in the stars to hold our destiny but in ourselves.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "I would challenge you to a battle of wits, but I see you are unarmed!",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "The fault, dear Brutus, is not in our stars, but in ourselves.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Be not afraid of greatness. Some are born great, some achieve greatness, and others have greatness thrust upon them.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Love looks not with the eyes, but with the mind, and therefore is winged Cupid painted blind.",
                    PersonId = williamShakespeareId
                },
                new Quote()
                {
                    Text = "Love all, trust a few, do wrong to none.",
                    PersonId = williamShakespeareId
                }
            };

            foreach (var quote in quotes)
            {
                context.Quotes.Add(quote);
            }

            context.SaveChanges();

            return quotes;
        }
    }
}