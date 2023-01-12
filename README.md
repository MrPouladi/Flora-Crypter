# Flora-Crypter
A simple Crypter that is used to hide malware and lower detection rate.

This crypter uses the codedom compiler to take the stub that is in base64 currently linked to a discord server incase a user wanted to remotly update the stub.

Now the b64 encoded string is the raw sourcecode of the file. Why? you may ask well by providing the sourcecode to the codedom compiler it will be able to compile the source with modifications like adding and icon. the program works as of now but will be updated as I reasearch more methods and modules. 

#Massive Disclamer
This sourcecode is for educational purposes only...

The reason I have shared my project is to allow users and analysts to see how a modern crypter can be created and how it can function this is an entirely unique builder that uses methods that other don't sharing this will educate and help other find out how to make their own crypter and how to stop it. 

#Notes
x32 only!

At the moment this can only use this with x32 exe. At some point I will add compatability with x64 using a runpe and share the source aswell.

make sure to know the windows api well if you are looking into a RunPE there are many techniques to making malware undetected but the windows api will come in handy.

#Icon replacer

An amazing feature of codedom is the fact that when you compile an exe it can replace the standard boring exe look although at the moment the icon tool is kinda buggy.
