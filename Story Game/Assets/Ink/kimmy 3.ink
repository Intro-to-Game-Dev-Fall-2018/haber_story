VAR money = 25
VAR devmode = 1

VAR dice = false
VAR jumprope = false
VAR chalk = false
VAR cards = false

VAR diceCost = 6
VAR jumpropeCost = 8
VAR chalkCost = 11
VAR cardsCost = 7

/*

=== CHAR_NAME
{not intro: -> intro}
-> choice

= choice
+ [Play game]
-> play
+ Bye
-> LOCATION

= play
-> playfunction -> friendsuccess

= intro
-> choice

= friendsuccess
-> choice

*/
-> intro_scene

=== intro_scene ===
#bg: home
char;
Late 1960s, West Philadelphia. 
Your mom is standing on the porch.
+ [Talk to Mom]
-> scene 
+ {devmode} [Skip Intro]
-> map

= scene 
#ch: Will #ch: Mom #ch: Carlton
char; Will,Mom,Carlton
Will:           Mom! Look! God sent me a baby!
Mom:            ...Excuse me?
Will:           Her name is Carlton!
Carlton:         ...
Carlton:          (Carlton remains silent.)
Mom:            That… No, Will. God did not send you a baby.
Will:           What do you mean…? You said God sends people babies sometimes! You told me that.
Mom:            Well… nevermind what I said. It doesn’t apply to you yet. God isn’t about to send you a baby anytime soon, trust me.
Will:           What! Why? I wished for a baby, and he granted my wish. Isn’t it obvious?
Mom:            Where did you find this little girl? Honey, where’s your house?
Carlton:         ...
Carlton:          (Carlton remains silent.)
Mom:            Carlton, can you tell me where your parents are?
Carlton:          I can go home later if I want…
Will:           Well maybe God didn’t send her, but she came out of nowhere! Carlton, you just… appeared, right? Where did you come from?
Carlton:          Ferry Street... I untied myself from the porch so I could go for a walk…
+[How strange.]
-Mom:           It’s ok dear, why don't you take Carlton home… you said it’s on Ferry Street? Your parents are probably worried.
* [Head to Carlton's house]
-> Carlton_house_intro

= Carlton_house_intro
#bg; ferry st
Carlton's house is on a quiet street next to a toy store.
* [Knock]
- Carlton's mother opens the door.
Mrs.Munro:            Thank you for finding Carlton and walking her home. What's your name, dear?
* [I’m Will…]
Will:           I’m Will…
* [Uhhhhhh]
    Will: Uhhhh...
    Mrs.Munro:         You do Have a name, don't you?
    ** [Will]
    --Will:            Will.
- Mrs.Munro:          I don’t know many kids as responsible as you, walking Carlton all the way home. I hope you two can be friends. I know Carlton could learn a lot from you.
Carlton:          My… friend?
* [Yes!]Will:            Yes! I’d love to be friends, Carlton. Can I come by and play with you tomorrow?
-Mrs.Munro:           I’ve been looking for a babysitter, actually. Her grandma was helping with that before, but she… well, she can’t anymore.
* [Yes]
* [Why?]
Mrs.Munro:            Carlton’s normally alright in her harness on the porch, but she’s getting a little old for that…
    ** [Yes]
-Will:          Wow! Yes, please! I’d love to!
Mrs.Munro:            If you’d like to play with Carlton tomorrow, I’d be happy to pay you a quarter to keep an eye on her.
* [I’ll be here.]Will:            I'll be here first thing! Wow, I didn’t expect to land a job today. Thanks so much! Bye bye Carlton, and Mrs...?
-Mrs.Munro:           Mrs. Munro. Again, thank you for giving Carlton a hand. It was nice meeting you, Will.
Will:           Likewise.
Will:           Bye bye.
+ [Come back tomorrow ] 
-> pickup_Carlton

= pickup_Carlton
#bg; ferry st
Will:           Mornin’ Carlton! I’m here to babysit, like I promised! Is your mom around?
Carlton:          My mommy’s not inside. She left already.
Will:           Oh, ok… Um, well… Is there anything you’d like to do today, Carlton?
Carlton:          No… I don’t know.
- (choose_activity)
* [Friends]
Will:           That’s ok, do you have a friend you’d like to visit?
Carlton:          No...
-> choose_activity
* [Watch TV]
Will:           Should we watch TV or something in your house?
Carlton:          We don’t have a TV. My dad is in there too, so we should go play somewhere else. He’s busy.
->choose_activity
* [Go outside] 
-Will:          Ok then! Want to walk around and play some games with the other kids?
Carlton:          Other kids…?
Will:           You know, the neighborhood kids. Like Donna. Isn’t she your age? You’re both going to be in Kindergarten, right?
Carlton:          Oh, yeah… I don’t think Donna is my friend though, so she probably wouldn’t want to play...
Will:           Well, let’s go become her friend! There's lots of other kids around, too. Like Anthony. I know him from school.
Carlton:          ...
* [Lets Go]
Will:           Come on, let’s go!
Carlton:          ...!
-> map

=== map ===
#bg; map #ch:
Where to next?
+ [Downtown] 
-> downtown
+ [Ferry st.] 
-> ferry_street
+ {downtown and ferry_street} [End Day] 
-> Done

=== ferry_street ===
#bg; ferry st
Dean's store is open. Donna sits on the sidewalk.
+ [Talk to Donna] -> donna
+ [Enter the store] -> store
+ [Map]
-> map

=== store
Dean:           Hey, Kid.
Will:           Hi, Dean.
{not intro:          -> intro}
+ [Buy stuff]
-> shop
+ [Exit]
-> outro

= shop
{money}c remaining
* {money > jumpropeCost}[Jump Rope ({jumpropeCost}c) ] -> buyJumprope
* {money > diceCost} [Dice ({diceCost}c)] -> buyDice
* {money > cardsCost} [Playing cards ({cardsCost}c)] -> buyCards
* {money > chalkCost} [Chalk ({chalkCost}c)] -> buyChalk
+ [That's all] -> outro

= buyChalk
~ money -= chalkCost
~ chalk++
Bought chalk
-> shop

= buyDice
~ money -= diceCost
~ dice++
Bought dice
-> shop

= buyJumprope
~ money -= jumpropeCost
~ jumprope++
Bought jump rope
-> shop

= buyCards 
~ money -= cardsCost
~cards++
Bought playing cards
->shop

= intro
Will:           This is Carlton. I’m babysitting her now.
-Dean:          Well lookit that, aren’t you all grown up. You gettin’ paid?
Carlton:          My mom pays Will a quarter a day.
* [That’s right!]Will:           That’s right! I’m here to buy some things… I mean, I haven’t gotten paid yet. This is my first day. But I have some money saved up!
-Dean:          Hah, I wish I had that kinda discipline. I blew my budget on fabric last week.
* [I need to save up money.]Will:           I need to save up money.For college, you know! My mom would get so mad if I didn’t plan ahead.
Dean:           Hah! Your mom’s got the right idea. I wish I’d saved up for college.
* [So what did you spend all your money on?]Will:           So what did you spend all your money on? Your sewing classes?
Dean:           Nah, that’s over. I’m workin’ on some Halloween costumes for my cousins… and some new pants for myself. You know, gotta apply those skills somehow.
Carlton:          I didn’t know people made clothes!
Dean:           They do, Carlton, they do. I make sweaters, dresses, hats--you name it.
** [Compliment]Will:           You should sell your clothes at Jordan Marsh! That’s where I always find the nicest clothes.
Dean:           Hah! That’s a long ways off for me. But maybe someday… anyways, what can I get for ya?
** [Huh]
--> shop

= outro
Will:           Thanks, Dean!
Carlton:          Thank you Mr. Dean!
Dean:           Bye bye girls. Have fun.
-> ferry_street

=== donna
Will:           Hi Donna.
{not intro:-> intro}
Donna:          Hi Will, Hi Carlton
-> choice

= choice
+ [Play game]
-> play
+ Bye[]! Donna
Talk to you later!
-> ferry_street

= play
-> playfunction -> friendsuccess

= intro
Donna:          What happened, Carlton? Did you untie yourself from the porch again?
Carlton:          ...
+ [Introduce self]Will:            Hi Donna! I’m babysitting Carlton now, so--
- Donna:            So you untied Carlton from the porch? Better not let her parents catch you.
+[First of all...]
Will:           First of all, I’m her babysitter. Second, she’s perfectly able to untie herself. She’s too old for that thing now, even her mom thinks so.
-Donna:         She should probably stay on her porch. We’re the same age, but my mom takes me everywhere so I won’t get lost. I bet Carlton would get lost if she wandered too far.
+[I don’t know about that.] 
Will:           I don’t know about that. Anyways, I was just going to ask if you wanna play with us... but I feel like you're being mean to Carlton.
-Donna:         Oh, no. I'm just being honest!
+ [Get along.]
Will:           Ok... well, I hope you two can get along, since you're neighbors... want to play a game with us?
-Donna:         Well, I’m trying to avoid Harold so it’s probably good to look busy. He keeps trying to tell me that my ears look childish. He is so snobby.
Carlton:          I like your ears.
Donna:          Oh, thanks. They’re new. Anyways, I wanna play a new game.
-> choice

= friendsuccess
Donna:          			...Are you gonna walk to Jordan Marsh? That’s where my babysitter used to take me.
+ [Maybe.]
-Will:          Maybe! Carlton doesn't seem to know too many people around town though, so I think we should save big trips for later.
Donna:          Playing is fine, but isn’t it boring sometimes? I need more friends  who will go with me to Jordan Marsh. I like going shopping there. I hide in the clothes racks sometimes.
Carlton:          Dad took me there once. He needed a new leather jacket. But then he bought another new guitar and mom got mad when we came home.
+ [Your dad is weird.]
-Will:          Haha, your dad is so weird.
Donna:          I don’t see your dad around much anymore, but I guess that’s because I’m not out on the porch like I used to be.
Carlton:          Donna used to be in a harness outside, like me.
Donna:          Yeah I used to wear a harness attached to the front door when my mom was cooking or doing laundry. It was so embarrassing.
Donna:          My mom said I’m too big for the harness. I go bike riding a lot now. I went by myself to Jordan Marsh yesterday and got these ears…
Carlton:          I like them.
+ [I like riding my bike to Jordan Marsh too!]
-Will:          I like riding my bike to Jordan Marsh too! Sometimes I’ll buy a ribbon if I save up.
Carlton:          I’ve never worn a ribbon.
+ [Really?]
-Will:          Wow! Really? I can get you one, Carlton, don’t worry.
Carlton:          No thank you, I’m not supposed to spend any money. I don’t have any anyways.
+ [I'll get you one.]
-Will:          I’ll save up and get you one!
Donna:          Carlton, you would look nice in a ribbon. Cat ears too probably.
Carlton:          …Maybe.
-> choice

=== downtown ===
#bg; downtown
Jimmy is reading a comic book. Anthony and his sister are hanging out.
+ [Talk to Jimmy] 
-> jimmy
+ [Talk to Anthony] 
-> anthonyamber
+ [Map]
-> map

=== jimmy
Jimmy:          ...Hi Carlton.
Carlton:          Hi Jimmy…
{not intro: -> intro}
-> choice

= choice
+ [Play Game]
-> play
+ [Exit]
-> downtown

= play
-> playfunction -> friendsuccess

= intro 
+ [Whatcha reading?]
Will:			Whatcha reading there, Jimmy? Looks neat.
-Jimmy:			M-my comic… Archie...
Will:			Some of my friends at school read that! Did you get it at the bookstore?
Jimmy:			Yeah!
Carlton:			I’ve never read a comic before.
Jimmy:			Y-you can borrow one of mine whenever you like, Carlton! And then we can uh…
Jimmy:			We can talk about it and pick our--our favorite characters!
+[That’s so nice of you!]
Will:			Wow! That’s so nice of you, Jimmy! Guess you have a new friend, Carlton!
-Carlton:			I think… that sounds fun...
Jimmy:			A-anytime, anytime… um…
+ [Play a game with us.]
Will:			Say, are you free to play a game with us, Jimmy? We’ll teach you something new!
-Jimmy:			I’m not very good at games… b-but, if Carlton wants me to...
Will:			I’m teaching Carlton games and helping her make friends this summer.
Jimmy:			If you’re learning games, can I play games with you on the playground sometimes too, Carlton? Once school starts?
Carlton:			...Ok. I don’t play much at school but I will with you if you want.
Jimmy:			What! Oh! Yes… yes please…
-> choice

= friendsuccess
Jimmy:          Thanks for… playing nice and helping me because...
Jimmy:          Because I get nervous because… kids tease me for being slow sometimes and…
+ [They’re bullies.]
-Will:          They’re bullies. Don’t worry, you’re great. Right Carlton?
Carlton:          Yup!
Jimmy:          That’s nice of you…
Carlton:          Kids tease me too.
Jimmy:          Why would they tease you? You’re so nice…
Carlton:          I don’t know…
Carlton:          People get mad and ask me if I know how to talk…
+ [That’s so stupid.]
-Will:          That’s so stupid. It’s ok to be quiet, don’t let them get to you.
Will:           If anyone tries to bully either of you, let me know. I’ll deal with them.
Carlton:          The boys might try to tear your shirt though.
+ [I can run]
Will:           I’m the fastest runner in school. They can’t touch me. I’ll tell them to shut up and then--
+ [I can tell]
Will:           I mean I guess I’d just run away and tell my mom and dad…
+ [Bullies...]
Will:           I’m actually not that helpful with bullies, haha. They bug me too.
-Jimmy:         My mom says not to walk around too much alone.
Will:           Yes! Being with a buddy is a good idea.
Jimmy:          Maybe next year at school, Carlton… we can sit together at recess… I know that usually we’re both um… sitting alone… then maybe we won’t get picked on as much...
Carlton:          If you want, that sounds ok.
+ [stick together]
-Will:          You’ve never played together at school before? You two should stick together!
Jimmy:          W-well… we’ve only talked a couple times…
+ [Makes sense.]
Will:           Haha that makes sense, you’re both pretty quiet.
Jimmy:          Um, uh… will you…
Jimmy:          Does that mean…
Jimmy:          Uhhhh…
Carlton:          ...
Jimmy:          Will you be my friend, Carlton?
Carlton:          ...Ok.
Will:           Haha, you two...
->choice

=== anthonyamber
Will:           Hey Anthony.
Anthony:        Hi Will.
{not intro: -> intro}
-> choice

= choice
+ [Play Game]
-> play
+ [Exit]
-> downtown

= play
-> playfunction -> friendsuccess

= intro
Anthony:            It’s so weird seeing you outside of school, haha.
Amber:			I’m Amber!
Anthony:			This is my little sister, Amber. Is that your sister, Will? I didn’t know you had a little sister.
+ [Babysitter] 
Will:			Oh, no… This is Carlton. I’m her babysitter.
-Anthony:			Isn’t Carlton the girl that Jim--
Amber:			Anthony! I know you’re mad at Jimmy, but--
Anthony:			I know, I know, nevermind.
+ [Uhhhh… what?] 
Will:			Uhhhh… what? What’s the gossip?
-Amber:			Nevermind! Hi Carlton. I remember seeing you walk to school last year. Isn’t it a bit far to walk? You should ride a bike, at least.
Carlton:			Oh… I don’t know.
Anthony:			Are you two headed somewhere? You should hang out with Amber and I.
+ [We'd like to play]
Will:			Well, we’d like to play a game!
-Anthony:			We’d been playing games with Harold earlier… but maybe we could try something new? Amber’s kinda picky though--fair warning.
Amber:			Am not!
-> choice

= friendsuccess
Will:           I haven’t seen you out with Amber before. Usually you’re just walking your dog or at baseball practice.
Anthony:            Unfortunately, Mom told us to stick together this summer.
Amber:          I don’t like going outside alone.
Amber:          Some boy was chasing me last month and I tripped and he stole my allowance.
Carlton:          I hate boys.
Anthony:            			Ouch. Can’t really blame you though. There are definitely some bad guys around…
Carlton:          There are some boys you don’t like…? I thought that all boys are friends?
+ [Hahaha]
- Will:         Haha, no Carlton. Some boys really hate each other.
Anthony:            That’s right. Haha, I can’t even stand most of the guys in my class… they don’t pick on me much, but some of the things they say to the girls…
Carlton:          My mom told me to stay away from boys because they might hurt me.
Amber:          My mom says that too.
+ [Don't worry]
-Will:          Well, Anthony and I won’t let the bad ones near you. Don’t worry! I’m the fastest runner at school, so I’ll just… carry you.
Anthony:            Haha, aren’t you a majorette, Will? Just kick them in the… you know.
+ [Gross.]
-Will:          Gross. Not around these little girls, Anthony.
Amber:          Anthony! Mom said no kicking. No punching. No nothing.
Anthony:            I’m just kidding. But Will does have a pretty high kick. All you majorettes kick like crazy in those dance routines… it looks kind of painful.
+ [Watch out]
-Will:          I’m better with a baton…
Carlton:          I want to play with a baton... dad took me to see sports once and I saw the ladies twirling batons. We were far in the back, so they looked really tiny.
Anthony:            You should come to some baseball games Carlton. I’m on the team. You and Amber can watch together.
Amber:          I’d like that!
Carlton:          I do like sports. My dad might even take me, if I ask nicely.
+ [Awesome]
-Will:          Awesome! I’ll come too! It’s fun to watch your baseball games, Anthony.
Anthony:            I’ll let you know when the season starts.
-> choice

=== playfunction ===
* {dice} [Play dice]
* {chalk} [Play Hopskotch]
* {jumprope} [Play Jumprope]
* {cards} [Play Poker]
+ [Patty cake]
- Wow! such fun.
->->

=== Done
->DONE