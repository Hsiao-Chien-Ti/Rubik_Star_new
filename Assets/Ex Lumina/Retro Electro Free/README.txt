INTRODUCTION
============

Thanks for using Ex Lumina Corporation's "RetroElectroFree" pack! This package contains some low-poly prefabs that look like the panel controls you see on electronic equipment from the latter part of the 20th century. They hold up well at close viewing, offering a superior choice over texture mapping. Also, you can make as many different models with them as you want, avoiding the obvious repetition you sometimes see with texture mapping.

Positioning prefabs in models can be time-consuming in Unity, but easy in a 3D modeling program like Blender or SketchUp. Ex Lumina suggests that you use simple "stand-in" models made of boxes and spheres to represent these prefabs while you create your models in that kind of program. We have included a simple script that you can use to replace your stand-ins with instances of these prefabs after you have imported your model into Unity.


NEW IN VERSION 1.1
==================

There is a new oscilloscope prefab that applies a simple animation to the waveform. Use the ScopeMoving prefab. Change its Speed setting in the Trace Animator component of its Trace child object.

The needle position in the AmmeterBlack3inOn prefab is now settable via code. Change the amps value in the Needle component of the prefab. If you want to set a fixed position that doesn't change if other code modifies the amps member, just assign that value to the Needle component's FixedAmps property. You can start continuous updating again by setting its Continuous property to true (and stop it by setting that property to false, or by setting the FixedAmps property to any value). Useful values range from 0 to 50, though you can use any floating value.

There are now prefabs for turning the toggle switch and the five colored lights on and off. Use ToggleOnOff and the Light[Red|Green|Blue|White|Yellow]OnOff prefabs, and set the On or Off property to true or false.

WHAT'S INCLUDED
===============

Here's the inventory:

Two Ammeters:
	one on, one off (both three inches wide)
	
Five Knobs:
	three 12mm in various colors
	one 19mm with a brushed metal texture
	one 31mm with a pointer
	
Fifteen Lights:
	five on in various colors, five off in the same colors, and five that can be turned on an off via code (all 18mm across)
	
Three RCA jacks:
	three in various colors (all 8.3mm across)
	
Three Oscilloscope Screens:
	one on, one off, one on and animated (all five inches wide)
	
Three Toggle switches:
	one on, one off, and one that can be turned on and off via code (both one inch high with a half-inch base)
	
Collider meshes are provided for the more complex shapes. Use a box collider or the prefab's mesh itself for the simpler models.

Also included is an editor script that will automatically replace GameObjects in your hierarchy with prefabs of the same, or similar, names. This lets you create your retro electronic equipment in a 3D modeling application, then import your model into Unity, and replace your models with these prefabs.


ADDING PREFABS TO YOUR MODELS AUTOMATICALLY
===========================================

After creating your model in a 3D modeling prorgram, import your model into Unity and create an instance of it in your hierarchy.

Note that your instance will probably first appear as a "model prefab" when you create an instance of it in the hierarchy. Before replacing any part of it, select it in the hierarchy with the mouse, then right-click on it in the hierarchy and select "Unpack Prefab." This converts your model prefab instance into ordinary GameObjects that can be replaced by Ex Lumina's prefabs.

To run the script, select either the one GameObject in the hierarchy you want to replace, or the one GameObject in the hierarchy whose children you want to replace. Then pick "ExLumina / Replace Selected Object" or "ExLumina / Replace Child Objects" to replace either just the selected GameObject, or all the children of the selected GameObject, whichever is appropriate to what you want to do.

All GameObjects to be replaced have their name compared to the names of the prefabs. Replacement happens if the names match exactly, or the GameObject name matches exactly up to, but not including, its first space character or its first "#" character. (We're using these matching rules because Unity, as well as your own 3D modeling software, might add numbers starting with spaces or "#" characters, to insure that each component in your model has a unique name.)

For example, you might have GameObjects with these names:

	LightBlueOn
	LightBlueOn#1
	LightBlueOn Upper Left

All three of these GameObjects will be replaced with instances of the LightBlueOn prefab. The GameObjects will be destroyed and the prefab instances will have the same names as the GameObjects they replace.

As a different example, you might have GameObjects with these names:

	Light Blue On
	LightBlueOn1
	LightBlueOn_UpperLeft
	
None of these GameObjects will be replaced or destroyed.

When the script completes, it generates a short report on the console, indicating the number of GameObjects replaced with prefabs ("Replaced"), the number of prefabs it encountered and could not replace ("Prefabs"), the number of GameObjects it encountered for which there was no prefab with a matching name ("No replacement"), and the number for which there were two or more prefabs with matching names ("Ambiguous"). You can safely include your own GameObjects with names that don't match any prefabs if you want those to stayed unchanged when you run the script. This allows you to mix the RetroElectro prefabs with your own creations as child GameObjects of the same parent, replacing only the GameObjects with names that match the RetroElectro prefabs. (Unless you add your own prefabs to the Ex Lumina / RetroElectroFree / Prefabs folder, the number of ambiguous names should always be zero.)

Note that the model you imported is never changed by this process. Using the script only affects instances of your model in the hierarchy, not the original version in your project.


ATTRIBUTION
===========

You are free to use these prefabs in your own Unity games. Please just be sure to mention in your game instructions or credit roll that you used models provided by "Ex Lumina."

Please send questions or comments to info@exlumina.com.


NO WARRANTY
===========

This package, including its scripts, is offered for free AS-IS, with NO WARRANTY OF ANY KIND. You assume all risks associated with its use.