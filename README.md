# GHAutoSave
![Plugin ÉçÉS](GHAutoSave/docs/AutoSave.png)

A Grasshopper plugin that automatically saves your `.gh` files at a fixed interval.  
AutoSave is controlled from the **Display menu**, not by placing components on the canvas.

This design avoids component dependency issues when sharing Grasshopper files with others.

---

## Features

- AutoSave ON/OFF from **Display to AutoSave**
- Fixed autosave interval: **30 seconds**
- No Grasshopper components required
- No dependency stored inside `.gh` files
- Safe for file sharing across devices
- Visual reminder on canvas when the file has not been saved yet

---

## How It Works
![Screenshot](GHAutoSave/docs/picture.png)

- When **AutoSave is ON**:
  - Saved `.gh` files are automatically saved every 30 seconds
  - Unsaved definitions show a reminder directly on the canvas
- When **AutoSave is OFF**:
  - No background behavior at all

AutoSave only works after the file has been saved at least once, following GrasshopperÅfs native safety rules.

---

## Installation

### Option 1: Yak (recommended)
*(Coming soon)*

### Option 2: Manual install
1. Download the latest release
2. Copy `GHAutoSave.gha` into your Grasshopper Libraries folder:
