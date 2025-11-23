# ⚙️ Data And UI System

**Project Name:** ConfigurableUISystem | **Status:** Implementation Phase | **Platform:** PC / Mobile

---

## 💡 Overview
This project demonstrates the implementation of a professional, responsive user interface using **Unity's UI Toolkit**. It features a robust backend for managing user preferences (Audio, Graphics) using persistent data storage, ensuring settings are saved and loaded correctly across sessions.

This project highlights proficiency in **Technical UI Design** (separating layout from logic using UXML/USS) and **Data Management** via a centralised wrapper architecture.

## 🧱 Core Architectural Concepts

### 1. UI Toolkit Workflow (MVC Pattern)
* **Implementation:** Utilises **UXML** for structure and **USS** for styling, keeping the visual layer completely separate from the C# logic (`SettingsView.cs`).
* **Benefit:** Allows for rapid iteration on visual styles (themes) and responsive layouts without breaking the underlying code, mirroring modern web development standards.

### 2. Data Persistence (`PlayerPrefs` Wrapper)
* **Implementation:** A **`SettingsManager`** class acts as a centralised wrapper for `PlayerPrefs`. It handles type conversion, default values, and immediate saving.
* **Benefit:** Prevents "magic string" errors, centralises data handling, and ensures data integrity when accessing user settings from different parts of the application.

## ⚙️ Technical Stack
| Category | Detail | Purpose |
| :--- | :--- | :--- |
| **Engine** | Unity 2023+ (Unity 6.2) | The base development environment. |
| **UI Framework** | UI Toolkit | Modern, performance-oriented UI system (replaces uGUI). |
| **Styling** | USS (Unity Style Sheets) | Reusable styling for consistency across panels. |
| **Persistence** | PlayerPrefs / JSON | Saving user configuration locally. |

## 💾 Key Scripts
| Category | File Name | Purpose |
| :--- | :--- | :--- |
| **Managers (Data)** | SettingsManager.cs | Centralised Singleton that wraps `PlayerPrefs` to load, save, and apply settings (Volume, Quality). |
| **UI (Logic)** | SettingsView.cs | Handles UI Toolkit events (slider changes, toggles) and updates the view based on data from the Manager. |
| **UI (Visuals)** | MainMenu.uxml / MainTheme.uss | Defines the hierarchy and styling of the interface, keeping it separate from the C# logic. |

## 🗓️ Roadmap
| Status | Task | Feature Branch |
| :--- | :--- | :--- |
| ✅ | **Setup:** Repository creation and README setup. | `main` |
| 🚧 | **Persistence Layer:** Implement `SettingsManager.cs` to handle data. | `feature/settings-system` |
| ⬜ | **UI Construction:** Build the UXML layout and USS styles. | `feature/settings-system` |
| ⬜ | **Logic Integration:** Connect `SettingsView.cs` to the Manager. | `feature/settings-system` |
