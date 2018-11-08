VAR money = 25
VAR devmode = 1

Late 1960s, Massachusetts.
-> intro_scene

=== intro_scene ===
Your mom is standing on the porch.
+ [Talk to Mom]
-> mom_home_1
+ {devmode} [skip intro]
-> map

= mom_home_1
Mom! Look! God sent me a baby!
...Excuse me?
Her name is Kimmy!
-> kimmy_home_1

= kimmy_home_1
+ [It seems that Kimmy has something to say.]
...
(Kimmy remains silent.)
-> Nope

= Nope
* {X} [...] -> Y
* {not X} [...] -> X

= X
That… No, Dana. God did not send you a baby.

What do you mean…? You said God sends people babies sometimes! You told me that.

Well… nevermind what I said. It doesn’t apply to you yet. God isn’t about to send you a baby anytime soon, trust me.

What! Why? I wished for a baby, and he granted my wish. Isn’t it obvious?

Where did you find this little girl? Honey, where’s your house?
-> kimmy_home_1

= Y
Kimmy, can you tell me where your parents are?

I can go home later if I want…

Well maybe God didn’t send her, but she came out of nowhere! Kimmy, you just… appeared, right? Where did you come from?

Ferry Street... I untied myself from the porch so I could go for a walk…

+[How strange] -> Odd

= Odd
It’s ok dear, why don't you take Kimmy home… you said it’s on Ferry Street? Your parents are probably worried.

* [Head to Kimmy's house]
-Kimmy's house is on a quiet street next to a toy store. her harnass is on the porch.
* [Knock]
- Kimmy's mother opens the door.
Thank you for finding Kimmy and walking her home. What's your name, dear?
* I’m Dana…
* Uhhhhhh
    You do Have a name, don't you?
    ** Dana.
- I don’t know many kids as responsible as you, walking Kimmy all the way home. I hope you two can be friends. I know Kimmy could learn a lot from you.
My… friend?
* Yes![] I’d love to be friends, Kimmy. Can I come by and play with you tomorrow?
-I’ve been looking for a babysitter, actually. Her grandma was helping with that before, but she… well, she can’t anymore.
* [Yes]
* [Why?]
Kimmy’s normally alright in her harness on the porch, but she’s getting a little old for that…
    ** [Yes]
-Wow! Yes, please! I’d love to!
If you’d like to play with Kimmy tomorrow, I’d be happy to pay you a quarter to keep an eye on her.
* I’ll be here[.] first thing! Wow, I didn’t expect to land a job today. Thanks so much! Bye bye Kimmy, and Mrs...?
-Mrs. Munro. Again, thank you for giving Kimmy a hand. It was nice meeting you, Dana.
Likewise.
Bye bye.
+ [Come back tomorrow ] 
-> pickup_kimmy

=== pickup_kimmy
Mornin’ Kimmy! I’m here to babysit, like I promised! Is your mom around?
My mommy’s not inside. She left already.
Oh, ok… Um, well… Is there anything you’d like to do today, Kimmy?
No… I don’t know.
- (choose_activity)
* [Friends]
That’s ok, do you have a friend you’d like to visit?
No...
-> choose_activity
* [Watch TV]
Should we watch TV or something in your house?
We don’t have a TV. My dad is in there too, so we should go play somewhere else. He’s busy.
->choose_activity
* {choose_activity > 2 } [Go outside] 
-Ok then! Want to walk around and play some games with the other kids?
Other kids…?
You know, the neighborhood kids. Like Donna. Isn’t she your age? You’re both going to be in Kindergarten, right?
Oh, yeah… I don’t think Donna is my friend though, so she probably wouldn’t want to play...
Well, let’s go become her friend! There's lots of other kids around, too. Like Anthony. I know him from school.
...
+ [Lets Go]
Come on, let’s go!
...!
-> map

=== map ===
Where to next?
+ [Downtown] 
-> downtown
+ [Kimmy's Street] 
-> ferry_street
+ {downtown or ferry_street} [End Day] 
-> Done

=== ferry_street ===
Dean's store is open. Donna sits on the sidewalk.
+ [Talk to Donna] -> donna
+ [Enter the store] -> store
+ [Map]
-> map

=== store
Hey, Kid.
Hi, Dean.
{not intro: -> intro}
+ [Buy stuff]
-> shop
+ [Exit]
-> outro

= shop
You have {money} cents to spend
* {money > 8 }[Jump Rope (8c) ] -> jumprope
* {money > 6} [Dice (6c)] -> dice
* {money > 7} [Playing cards (7c)] -> cards
* {money > 11} [Chalk (11c)] -> chalk
* {money > 3 } [Notepad (3c)] -> notepad
+ [That's all] -> outro

=notepad
~ money -= 3
bought notepad
-> shop

=chalk
~ money -= 11
Bought chalk
-> shop

= dice
~ money -= 6
Bought dice
-> shop

= jumprope
~ money -= 8
Bought jump rope
-> shop

= cards 
~ money -= 7
Bought playing cards
->shop

= intro
<> This is Kimmy. I’m babysitting her now.
-Well lookit that, aren’t you all grown up. You gettin’ paid?
My mom pays Dana a quarter a day.
* That’s right![] I’m here to buy some things… I mean, I haven’t gotten paid yet. This is my first day. But I have some money saved up!
-Hah, I wish I had that kinda discipline. I blew my budget on fabric last week.
* I need to save up money.[] For college, you know! My mom would get so mad if I didn’t plan ahead.
Hah! Your mom’s got the right idea. I wish I’d saved up for college.
* So what did you spend all your money on?[] Your sewing classes?
Nah, that’s over. I’m workin’ on some Halloween costumes for my cousins… and some new pants for myself. You know, gotta apply those skills somehow.
I didn’t know people made clothes!
They do, Kimmy, they do. I make sweaters, dresses, hats--you name it.
** [Compliment] You should sell your clothes at Jordan Marsh! That’s where I always find the nicest clothes.
Hah! That’s a long ways off for me. But maybe someday… anyways, what can I get for ya?
** [Huh]
--> shop

= outro
Thanks, Dean!
Thank you Mr. Dean!
Bye bye girls. Have fun.
-> ferry_street

=== donna
Hi Donna.
{not intro: -> intro}
Hi Dana, Hi Kimmy
-> choice

= choice
+ [Play game]
-> play
+ Bye[]! Donna
Talk to you later!
-> ferry_street

= play
-> donna

= intro
What happened, Kimmy? Did you untie yourself from the porch again?
...
* [Introduce self] Hi Donna! I’m babysitting Kimmy now, so--
- So you untied Kimmy from the porch? Better not let her parents catch you.

*First of all[...], I’m her babysitter. Second, she’s perfectly able to untie herself. She’s too old for that thing now, even her mom thinks so.
-She should probably stay on her porch. We’re the same age, but my mom takes me everywhere so I won’t get lost. I bet Kimmy would get lost if she wandered too far.
*I don’t know about that.[] Anyways, I was just going to ask if you wanna play with us... but I feel like you're being mean to Kimmy.
-Oh, no. I'm just being honest!
* [Get along.]Ok... well, I hope you two can get along, since you're neighbors... want to play a game with us?
-Well, I’m trying to avoid Harold so it’s probably good to look busy. He keeps trying to tell me that my ears look childish. He is so snobby.
I like your ears.
Oh, thanks. They’re new. Anyways, I wanna play a new game.
-> choice

=== downtown ===
Jimmy is reading a comic book. Anthony and his sister are hanging out.
+ [Talk to Jimmy] 
-> jimmy
+ [Talk to Anthony] 
-> anthony
+ [Map]
-> map

=== jimmy
...Hi Kimmy.
Hi Jimmy…
{not intro: -> intro}
-> choice

= choice
+ [Play Game]
-> play
+ [Exit]
-> downtown

= play
-> jimmy

= intro 
...
* Whatcha reading[?] there, Jimmy? Looks neat.
- M-my comic… Archie...
*Some of my friends[read that!] at school read that! Did you get it at the bookstore?
-Yeah!
I’ve never read a comic before.
Y-you can borrow one of mine whenever you like, Kimmy! And then we can uh…
We can talk about it and pick our--our favorite characters!
* Wow! That’s so nice[.] of you, Jimmy! Guess you have a new friend, Kimmy!
- I think… that sounds fun...
A-anytime, anytime… um…
* [Play with us] Say, are you free to play a game with us, Jimmy? We’ll teach you something new!
- I’m not very good at games… b-but, if Kimmy wants me to...
* I’m teaching Kimmy games[.] and helping her make friends this summer.
If you’re learning games, can I play games with you on the playground sometimes too, Kimmy? Once school starts?
...Ok. I don’t play much at school but I will with you if you want.
What! Oh! Yes… yes please…
-> choice

=== anthony
Hey Anthony.
Hi Dana.
{not intro: -> intro}
-> choices

= choices
+ [Play Game]
-> play
+ [Exit]
-> downtown

= intro
<> It’s so weird seeing you outside of school, haha.
I’m Amber!
This is my little sister, Amber. Is that your sister, Dana? I didn’t know you had a little sister.
* [Babysitter] Oh, no… This is Kimmy. I’m her babysitter.
- Isn’t Kimmy the girl that Jim--
Anthony! I know you’re mad at Jimmy, but--
I know, I know, nevermind.
* Uhhhh… what?[] What’s the gossip?
- Nevermind! Hi Kimmy. I remember seeing you walk to school last year. Isn’t it a bit far to walk? You should ride a bike, at least.
Oh… I don’t know.
Are you two headed somewhere? You should hang out with Amber and I.
* [Play Game] Well, we’d like to play a game!
- We’d been playing games with Harold earlier… but maybe we could try something new? Amber’s kinda picky though--fair warning.
Am not!
-> choices

= play
-> anthony

=== Done
->DONE