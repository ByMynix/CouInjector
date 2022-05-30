# CouInjector
![CouInjector-Picture](https://bymynix.de/couinjector/assets/images/couinjector-picture-412x242.png)
 
[https://bymynix.de/couinjector/]
CouInjector (formerly MadInjector) is an open-source project since 11.09.2021 and no longer closed-source. From the 29.05.2022 it's a real Git project, as the previous versions consisted of a file structure and I was too lazy to make the effort.




# Compile
In this project "CouInjector" resources were embedded:

The resource "Injection", i.e. the injection file (branch in preparation).

The resource "Updater", a console application as auto-updater ([Branch-CouInjector-Auto-Updater](https://github.com/ByMynix/CouInjector/tree/CouInjector-Auto-Updater)), which takes care of automatic updates.

The resource "VAC-ByPass", i.e. the VAC-ByPass file (branch in preparation).

These three resources, which are already embedded in "CouInjector" can of course be replaced by compiling the two applications mentioned and then embedding them as resources.


Compile it in Release / x86









# Previous versions
Please note that up to version 1.9 there is a file structure and it is not a single, let alone one Visual Studio project, which cannot be compiled in a simple way to use. From version 2.0 onwards, it is without a Setup Compiler and "CouInjector" can be easily compiled.
