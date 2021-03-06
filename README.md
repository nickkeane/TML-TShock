# tModLoader & TShock Integration POC

This project demonstrates how you can get tModLoader (windows server) working along side TShock.

![Alt text](/Screenshots/ts_and_tml.png?raw=true "TML & TShock ")
![Alt text](/Screenshots/ts_cmd_tml_pc.png?raw=true "Optional Title")
![Alt text](/Screenshots/in_server.png?raw=true "Optional Title")



## Build & Compile

#### 1. Run git commands  
>`git clone https://github.com/AxeelAnder/TML-TShock`  
>`git submodule update --init --recursive`  

#### 2. Build and run OTAPI  
Run `./OTAPI/prebuild.ps1`   
Place `./TML/ReLogic.dll` into `./OTAPI/wrap/TerrariaServer/`  
Open `./OTAPI/OTAPI.Server.sln` and build whole solution  
Run OTAPI patcher and it will generate `./OTAPI/OTAPI.dll` when completed 

#### 3. Build and run TML-TShock Patcher
Just open the solution and build  
For convenience I move TShock's modifications(Modifications in TShock.4.OTAPI) to this patcher so they can be patched together  
You can do it, too. Just built them then copy directories to `./TML-TShockPatcher/Modifications/`  
>Or you can run TShock.Modifications.Bootstrapper   
>Then change TShock's reference of OTAPI.dll to `/TShock/TerrariaServerAPI/TShock.Modifications.Bootstrapper/bin/Debug/Output/OTAPI.dll` 

#### 4. Build TShock
Nothing need to explain, if you have problems, just contact with me. I'll reply as soon as possible.  

## DeathCradle:
I personally will not be continuing work on this as I have other priority work I need to focus on. 
Feel free to fork and maintain yourself!

I have had the code sitting for at least a year now and I have just updated it to the latest TML/TShock, but fair chance I have missed a few files in order to get the player into the world.
If you are serious in continuing this work I have my initial POC project that can get a TML player into the server and sync mods, you will just need to contact me so I know that there is interest.

## How the hell does this abomination work?
Well, basically it uses OTAPI to patch TML instead of the vanilla server. Then a few extra compatibility adjustments are made for TML to be happy.

### What about XNA?
Yes TML uses the real XNA libraries and TShock doesn't.
Instead of OTAPI shipping XNA shims, I have put in type redirectors in OTAPI, so that if a plugin was referencing the old OTAPI it can potentially work by being redirected to the "real" XNA again.

### What about ITile from OTAPI/TShock/TSAPI?
Yes it works, OTAPI's patcher is smart enough (or dynamic enough) to patch TML's Tile implementations into an interface. TShock only required a couple data type changes in HeapTile.cs

### What about plugins?
They are all screwed...at least partially. 
Basic plugins can potentially just work from TShock, as ITile will be there, and XNA references should be redirected
TML plugins might work if they use Tile arrays (due to the array being replaced), XNA wont be an issue for these

It's certainly possible for this project to use OTAPI's framework to patch dll's as they are loaded, in order to add ITile implementations and XNA redirections (if needed), which then may supported all plugins from both platforms.
