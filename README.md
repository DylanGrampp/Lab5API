# Encountered Issues:

1) I came across an error called Error 403: Forbidden. This was from not having a Default Request Header. I was able to fix this issue by adding a default request header that allows me to get requests from the Chess API. 

2) When working on getting an account creation date to display (variable named Joined), I encountered an issue with the Chess API times being in Unix Epoch. When I pulled the data for a well-known chess player named Hikaru, the timestamp returned as 1389043258. I tried looking into how to convert the timestamp into dd/mm/yyyy/time and found that C# has a method for dates and times. By messing with the method, I was able to put together DateTime.UnixEpoch.AddSeconds(Joined) which would convert the timestamp into 1/6/2014 9:20:58 PM.

3) Another error I am encountering is with setting up my GUI. Since my API is on await, it loads the main menu before the profile menu can finish loading the ToString(). I am able to set the main menu on a delay to fix the issue, however, it makes the application look choppy and I wouldn't say I like the way it looks. I was about to settle with adding my main menu into my ToString() but I really did not like how it looked and it would not completely clear the screen when I did a console clear. I did some research for an hour and I was FINALLY able to figure out that if I put my Display() in the main args on await and my Profile() in my switch statement on await, it would fix my issue completely... I did not think adding only await to the methods would fix my issue, instead, I was trying to use "await Task.Delay" and others such as "Run, WhenAll, WhenAny, etc" which none seemed to work.

4) I came across an issue creating my API. The leaderboard does not have a JSON context and the player stats JSON was a work in progress. This forces me to use different options to create my API. I have gone with displaying accounts with certain chess titles based on user input and viewing club details.
