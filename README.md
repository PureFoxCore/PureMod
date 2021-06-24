# PureMod - Simple mod for VRChat

## How to download:

- Automatic mode
  1. Download [latest installer](https://github.com/PureFoxCore/PureMod/releases/latest/download/PureModInstaller.exe)
  2. Launch it and press select button
  3. Select VRChat.exe file
  4. Press Update | Install

- Manual mode
  1. Open VRChat folder
  2. Create **Plugins** folder in VRChat folder and paste [PureModAutoUpdater](https://github.com/PureFoxCore/PureMod/releases/latest/download/PureModAutoUpdater.dll) there
     

## How to make your own module for this mod

1. Create new C# dll project in .Net framework 4.7.2
2. Add latest [PureModLoader](https://github.com/PureFoxCore/PureMod/releases/latest/download/PureModLoader.dll) to references
3. ```csharp
   // Make your class parent of ModuleBase class
   class BeautifulModule : ModuleBase
   ```
4. ```csharp
   // Also dont forget to override modulename and loadorder
   public override int LoadOrder => 1;
   public override string ModuleName => "Beautiful";
   ```
5. Build your mod in to **VRChat/PureMod/Mods** folder

###### Also [join our discord server](https://discord.gg/VCbeWNW)
