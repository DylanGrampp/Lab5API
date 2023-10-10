# Encountered Issues:

1) I came across an error called Error 403: Forbidden. This was from not having a Default Request Header. I was able to fix this issue by adding a default request header that allows me to get requests from the Chess API. 
2) When working on getting an account creation date to display (variable named Joined), I encountered an issue with the Chess API times being in Unix Epoch. When I pulled the data for a well-known chess player named Hikaru, the timestamp returned as 1389043258.
I tried looking into how to convert the timestamp into dd/mm/yyyy/time and found that C# has a method for dates and times. By messing with the method, I was able to put together DateTime.UnixEpoch.AddSeconds(Joined) which would convert the timestamp into 1/6/2014 9:20:58 PM.
