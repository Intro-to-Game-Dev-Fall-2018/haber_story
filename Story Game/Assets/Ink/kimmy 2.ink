Late 1960s, Massachusetts.

Kimmy follows you outside as the school bell rings. The weather is too nice to go straight home.
"Where should we go, Dana?"
-> map

=== map ===
Where to{| next}?
+ {park or town} [Go home] 
I guess we should go home
Ok, I was getting tired anyways
...
->home
* [Go to the park] 
Let's go to the park!
Yes! That's a great idea!
...
-> park
* [Go downtown] 
How about we go downtown?
Um. I'm not sure that's been written yet
...
-> map

=== home ===
Your mom stands on the porch.
{park and town : Where have you been Dana? It's late!}
+ [Talk to Mom]
-> mom_home_1

=== mom_home_1
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

What do you mean…? You said God sends people babie sometimes! You told me that.

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
It’s ok dear, let’s go to your house Kimmy… you said it’s on Ferry Street? Your parents are probably worried.

+[Head to Kimmy's house] -> Done

=== park ===
The park is vibrant with the energy of kids enjoying the spring weather.
{not jimmy: Jimmy reads a comic book on a bench.}
{not playground: The playground looks like it could be fun.}
* [Talk to Jimmy] -> jimmy
* [Play on playground] -> playground
+ {jimmy or playground} [Leave] -> map

== jimmy
Hi Jimmy, what are you reading?
{~Captain Underpants|Garfield|Tintin|Spiderman}, who's that?
This is my Baby Kimmy! I found her earlier today.
Hi Kimmy, I'm Jimmy.
...
+ [Kimmy?] -> kimmy_park_jimmy

= kimmy_park_jimmy 
Guess she's just shy... I'll get back to my comic then.
+ [Goodbye]
->park

== playground
Kimmy follows you to the top of the playground, the slide looms ominously before you.
I've never been on a slide before
+ [Slide together] ->
Let's go down together then.
-> slide_together
+ [Encourage] ->
you can do it!
-> slide_alone

= slide_together
Ok
...
+ [Slide]
-> slide

= slide_alone
Are you sure?
+ [Slide]
-> slide

= slide
The wind rushes through your hair as you go down the slide.
{slide_together: Kimmy beams back at you.}
{slide_alone: Kimmy waits at the bottom of the slide}
That was fun, I don't want to do it again though...
+ [Back to park]
-> park

=== town ===
people bustle about, you see a mailman, ice cream cart and a starbucks
-> map

=== Done
->DONE