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
Late 1960s, Massachusetts.
Your mom is standing on the porch.
+ [Talk to Mom]
-> scene 
+ {devmode} [skip intro]
-> map

= scene
Dana:           Mom! Look! God sent me a baby!
Mom:            ...Excuse me?
Dana:           Her name is Kimmy!
Kimmy:         ...
Kimmy:          (Kimmy remains silent.)
Mom:            That… No, Dana. God did not send you a baby.
Dana:           What do you mean…? You said God sends people babies sometimes! You told me that.
Mom:            Well… nevermind what I said. It doesn’t apply to you yet. God isn’t about to send you a baby anytime soon, trust me.
Dana:           What! Why? I wished for a baby, and he granted my wish. Isn’t it obvious?
Mom:            Where did you find this little girl? Honey, where’s your house?
Kimmy:         ...
Kimmy:          (Kimmy remains silent.)
Mom:            Kimmy, can you tell me where your parents are?
Kimmy:          I can go home later if I want…
Dana:           Well maybe God didn’t send her, but she came out of nowhere! Kimmy, you just… appeared, right? Where did you come from?
Kimmy:          Ferry Street... I untied myself from the porch so I could go for a walk…
+[How strange.]
-Mom:           It’s ok dear, why don't you take Kimmy home… you said it’s on Ferry Street? Your parents are probably worried.
* [Head to Kimmy's house]
-> kimmy_house_intro

= kimmy_house_intro
Kimmy's house is on a quiet street next to a toy store. her harnass is on the porch.
* [Knock]
- Kimmy's mother opens the door.
Mrs.Munro:            Thank you for finding Kimmy and walking her home. What's your name, dear?
* [I’m Dana…]
Dana:           I’m Dana…
* Uhhhhhh
   Mrs.Munro:         You do Have a name, don't you?
    ** Dana:            Dana.
- Mrs.Munro:          I don’t know many kids as responsible as you, walking Kimmy all the way home. I hope you two can be friends. I know Kimmy could learn a lot from you.
Kimmy:          My… friend?
* [Yes!]Dana:            Yes! I’d love to be friends, Kimmy. Can I come by and play with you tomorrow?
-Mrs.Munro:           I’ve been looking for a babysitter, actually. Her grandma was helping with that before, but she… well, she can’t anymore.
* [Yes]
* [Why?]
Mrs.Munro:            Kimmy’s normally alright in her harness on the porch, but she’s getting a little old for that…
    ** [Yes]
-Dana:          Wow! Yes, please! I’d love to!
Mrs.Munro:            If you’d like to play with Kimmy tomorrow, I’d be happy to pay you a quarter to keep an eye on her.
* [I’ll be here.]Dana:            I'll be here first thing! Wow, I didn’t expect to land a job today. Thanks so much! Bye bye Kimmy, and Mrs...?
-Mrs.Munro:           Mrs. Munro. Again, thank you for giving Kimmy a hand. It was nice meeting you, Dana.
Dana:           Likewise.
Dana:           Bye bye.
+ [Come back tomorrow ] 
-> pickup_kimmy

= pickup_kimmy
Dana:           Mornin’ Kimmy! I’m here to babysit, like I promised! Is your mom around?
Kimmy:          My mommy’s not inside. She left already.
Dana:           Oh, ok… Um, well… Is there anything you’d like to do today, Kimmy?
Kimmy:          No… I don’t know.
- (choose_activity)
* [Friends]
Dana:           That’s ok, do you have a friend you’d like to visit?
Kimmy:          No...
-> choose_activity
* [Watch TV]
Dana:           Should we watch TV or something in your house?
Kimmy:          We don’t have a TV. My dad is in there too, so we should go play somewhere else. He’s busy.
->choose_activity
* [Go outside] 
-Dana:          Ok then! Want to walk around and play some games with the other kids?
Kimmy:          Other kids…?
Dana:           You know, the neighborhood kids. Like Donna. Isn’t she your age? You’re both going to be in Kindergarten, right?
Kimmy:          Oh, yeah… I don’t think Donna is my friend though, so she probably wouldn’t want to play...
Dana:           Well, let’s go become her friend! There's lots of other kids around, too. Like Anthony. I know him from school.
Kimmy:          ...
* [Lets Go]
Dana:           Come on, let’s go!
Kimmy:          ...!
-> map

=== map ===
Where to next?
+ [Downtown] 
-> downtown
+ [Kimmy's Street] 
-> ferry_street
+ {downtown and ferry_street} [End Day] 
-> Done

=== ferry_street ===
Dean's store is open. Donna sits on the sidewalk.
+ [Talk to Donna] -> donna
+ [Enter the store] -> store
+ [Map]
-> map

=== store
Dean:           Hey, Kid.
Dana:           Hi, Dean.
{not intro:          -> intro}
+ [Buy stuff]
-> shop
+ [Exit]
-> outro

= shop
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
Dana:           This is Kimmy. I’m babysitting her now.
-Dean:          Well lookit that, aren’t you all grown up. You gettin’ paid?
Kimmy:          My mom pays Dana a quarter a day.
* [That’s right!]Dana:           That’s right! I’m here to buy some things… I mean, I haven’t gotten paid yet. This is my first day. But I have some money saved up!
-Dean:          Hah, I wish I had that kinda discipline. I blew my budget on fabric last week.
* [I need to save up money.]Dana:           I need to save up money.For college, you know! My mom would get so mad if I didn’t plan ahead.
Dean:           Hah! Your mom’s got the right idea. I wish I’d saved up for college.
* [So what did you spend all your money on?]Dana:           So what did you spend all your money on? Your sewing classes?
Dean:           Nah, that’s over. I’m workin’ on some Halloween costumes for my cousins… and some new pants for myself. You know, gotta apply those skills somehow.
Kimmy:          I didn’t know people made clothes!
Dean:           They do, Kimmy, they do. I make sweaters, dresses, hats--you name it.
** [Compliment]Dana:           You should sell your clothes at Jordan Marsh! That’s where I always find the nicest clothes.
Dean:           Hah! That’s a long ways off for me. But maybe someday… anyways, what can I get for ya?
** [Huh]
--> shop

= outro
Dana:           Thanks, Dean!
Kimmy:          Thank you Mr. Dean!
Dean:           Bye bye girls. Have fun.
-> ferry_street

=== donna
Dana:           Hi Donna.
{not intro:-> intro}
Donna:          Hi Dana, Hi Kimmy
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
Donna:          What happened, Kimmy? Did you untie yourself from the porch again?
Kimmy:          ...
+ [Introduce self]Dana:            Hi Donna! I’m babysitting Kimmy now, so--
- Donna:            So you untied Kimmy from the porch? Better not let her parents catch you.
+[First of all...]
Dana:           First of all, I’m her babysitter. Second, she’s perfectly able to untie herself. She’s too old for that thing now, even her mom thinks so.
-Donna:         She should probably stay on her porch. We’re the same age, but my mom takes me everywhere so I won’t get lost. I bet Kimmy would get lost if she wandered too far.
+[I don’t know about that.] 
Dana:           I don’t know about that. Anyways, I was just going to ask if you wanna play with us... but I feel like you're being mean to Kimmy.
-Donna:         Oh, no. I'm just being honest!
+ [Get along.]
Dana:           Ok... well, I hope you two can get along, since you're neighbors... want to play a game with us?
-Donna:         Well, I’m trying to avoid Harold so it’s probably good to look busy. He keeps trying to tell me that my ears look childish. He is so snobby.
Kimmy:          I like your ears.
Donna:          Oh, thanks. They’re new. Anyways, I wanna play a new game.
-> choice

= friendsuccess
Donna:          			...Are you gonna walk to Jordan Marsh? That’s where my babysitter used to take me.
+ [Maybe.]
-Dana:          Maybe! Kimmy doesn't seem to know too many people around town though, so I think we should save big trips for later.
Donna:          Playing is fine, but isn’t it boring sometimes? I need more friends  who will go with me to Jordan Marsh. I like going shopping there. I hide in the clothes racks sometimes.
Kimmy:          Dad took me there once. He needed a new leather jacket. But then he bought another new guitar and mom got mad when we came home.
+ [Your dad is weird.]
-Dana:          Haha, your dad is so weird.
Donna:          I don’t see your dad around much anymore, but I guess that’s because I’m not out on the porch like I used to be.
Kimmy:          Donna used to be in a harness outside, like me.
Donna:          Yeah I used to wear a harness attached to the front door when my mom was cooking or doing laundry. It was so embarrassing.
Donna:          My mom said I’m too big for the harness. I go bike riding a lot now. I went by myself to Jordan Marsh yesterday and got these ears…
Kimmy:          I like them.
+ [I like riding my bike to Jordan Marsh too!]
-Dana:          I like riding my bike to Jordan Marsh too! Sometimes I’ll buy a ribbon if I save up.
Kimmy:          I’ve never worn a ribbon.
+ [Really?]
-Dana:          Wow! Really? I can get you one, Kimmy, don’t worry.
Kimmy:          No thank you, I’m not supposed to spend any money. I don’t have any anyways.
+ [I'll get you one.]
-Dana:          I’ll save up and get you one!
Donna:          Kimmy, you would look nice in a ribbon. Cat ears too probably.
Kimmy:          …Maybe.
-> choice

=== downtown ===
Jimmy is reading a comic book. Anthony and his sister are hanging out.
+ [Talk to Jimmy] 
-> jimmy
+ [Talk to Anthony] 
-> anthonyamber
+ [Map]
-> map

=== jimmy
Jimmy:          ...Hi Kimmy.
Kimmy:          Hi Jimmy…
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
Dana:			Whatcha reading there, Jimmy? Looks neat.
-Jimmy:			M-my comic… Archie...
Dana:			Some of my friends at school read that! Did you get it at the bookstore?
Jimmy:			Yeah!
Kimmy:			I’ve never read a comic before.
Jimmy:			Y-you can borrow one of mine whenever you like, Kimmy! And then we can uh…
Jimmy:			We can talk about it and pick our--our favorite characters!
+[That’s so nice of you!]
Dana:			Wow! That’s so nice of you, Jimmy! Guess you have a new friend, Kimmy!
-Kimmy:			I think… that sounds fun...
Jimmy:			A-anytime, anytime… um…
+ [Play a game with us.]
Dana:			Say, are you free to play a game with us, Jimmy? We’ll teach you something new!
-Jimmy:			I’m not very good at games… b-but, if Kimmy wants me to...
Dana:			I’m teaching Kimmy games and helping her make friends this summer.
Jimmy:			If you’re learning games, can I play games with you on the playground sometimes too, Kimmy? Once school starts?
Kimmy:			...Ok. I don’t play much at school but I will with you if you want.
Jimmy:			What! Oh! Yes… yes please…
-> choice

= friendsuccess
Jimmy:          Thanks for… playing nice and helping me because...
Jimmy:          Because I get nervous because… kids tease me for being slow sometimes and…
+ [They’re bullies.]
-Dana:          They’re bullies. Don’t worry, you’re great. Right Kimmy?
Kimmy:          Yup!
Jimmy:          That’s nice of you…
Kimmy:          Kids tease me too.
Jimmy:          Why would they tease you? You’re so nice…
Kimmy:          I don’t know…
Kimmy:          People get mad and ask me if I know how to talk…
+ [That’s so stupid.]
-Dana:          That’s so stupid. It’s ok to be quiet, don’t let them get to you.
Dana:           If anyone tries to bully either of you, let me know. I’ll deal with them.
Kimmy:          The boys might try to tear your shirt though.
+ [I can run]
Dana:           I’m the fastest runner in school. They can’t touch me. I’ll tell them to shut up and then--
+ [I can tell]
Dana:           I mean I guess I’d just run away and tell my mom and dad…
+ [Bullies...]
Dana:           I’m actually not that helpful with bullies, haha. They bug me too.
-Jimmy:         My mom says not to walk around too much alone.
Dana:           Yes! Being with a buddy is a good idea.
Jimmy:          Maybe next year at school, Kimmy… we can sit together at recess… I know that usually we’re both um… sitting alone… then maybe we won’t get picked on as much...
Kimmy:          If you want, that sounds ok.
+ [stick together]
-Dana:          You’ve never played together at school before? You two should stick together!
Jimmy:          W-well… we’ve only talked a couple times…
+ [Makes sense.]
Dana:           Haha that makes sense, you’re both pretty quiet.
Jimmy:          Um, uh… will you…
Jimmy:          Does that mean…
Jimmy:          Uhhhh…
Kimmy:          ...
Jimmy:          Will you be my friend, Kimmy?
Kimmy:          ...Ok.
Dana:           Haha, you two...
->choice

=== anthonyamber
Dana:           Hey Anthony.
Anthony:        Hi Dana.
{not intro:          -> intro}
-> choice

= choice
+ [Play Game]
-> play
+ [Exit]
-> downtown

= play
-> playfunction -> friendsuccess

= intro
Dana:			Hey Anthony.
Anthony:			Hi Dana. It’s so weird seeing you outside of school, haha.
Amber:			I’m Amber!
Anthony:			This is my little sister, Amber. Is that your sister, Dana? I didn’t know you had a little sister.
+ [Babysitter] 
Dana:			Oh, no… This is Kimmy. I’m her babysitter.
-Anthony:			Isn’t Kimmy the girl that Jim--
Amber:			Anthony! I know you’re mad at Jimmy, but--
Anthony:			I know, I know, nevermind.
+ [Uhhhh… what?] 
Dana:			Uhhhh… what? What’s the gossip?
-Amber:			Nevermind! Hi Kimmy. I remember seeing you walk to school last year. Isn’t it a bit far to walk? You should ride a bike, at least.
Kimmy:			Oh… I don’t know.
Anthony:			Are you two headed somewhere? You should hang out with Amber and I.
+ [We'd like to play]
Dana:			Well, we’d like to play a game!
-Anthony:			We’d been playing games with Harold earlier… but maybe we could try something new? Amber’s kinda picky though--fair warning.
Amber:			Am not!
-> choice

= friendsuccess
Dana:           I haven’t seen you out with Amber before. Usually you’re just walking your dog or at baseball practice.
Anthony:            Unfortunately, Mom told us to stick together this summer.
Amber:          I don’t like going outside alone.
Amber:          Some boy was chasing me last month and I tripped and he stole my allowance.
Kimmy:          I hate boys.
Anthony:            			Ouch. Can’t really blame you though. There are definitely some bad guys around…
Kimmy:          There are some boys you don’t like…? I thought that all boys are friends?
+ [Hahaha]
- Dana:         Haha, no Kimmy. Some boys really hate each other.
Anthony:            That’s right. Haha, I can’t even stand most of the guys in my class… they don’t pick on me much, but some of the things they say to the girls…
Kimmy:          My mom told me to stay away from boys because they might hurt me.
Amber:          My mom says that too.
+ [Don't worry]
-Dana:          Well, Anthony and I won’t let the bad ones near you. Don’t worry! I’m the fastest runner at school, so I’ll just… carry you.
Anthony:            Haha, aren’t you a majorette, Dana? Just kick them in the… you know.
+ [Gross.]
-Dana:          Gross. Not around these little girls, Anthony.
Amber:          Anthony! Mom said no kicking. No punching. No nothing.
Anthony:            I’m just kidding. But Dana does have a pretty high kick. All you majorettes kick like crazy in those dance routines… it looks kind of painful.
+ [Watch out]
-Dana:          I’m better with a baton…
Kimmy:          I want to play with a baton... dad took me to see sports once and I saw the ladies twirling batons. We were far in the back, so they looked really tiny.
Anthony:            You should come to some baseball games Kimmy. I’m on the team. You and Amber can watch together.
Amber:          I’d like that!
Kimmy:          I do like sports. My dad might even take me, if I ask nicely.
+ [Awesome]
-Dana:          Awesome! I’ll come too! It’s fun to watch your baseball games, Anthony.
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