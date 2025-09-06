# 🔐 Password Generator (C# Console App)

A simple password generator written in *C#* using *.NET 8.0*.  
It creates strong random passwords using lowercase, uppercase, digits, and symbols.  
The project is written with an *OOP structure* (services + utils).

---

## 📂 Project Structure
```
PasswordGenerator/
│
├── Program.cs
├── Services/
│ ├── PasswordGenerator.cs
│ └── EntropyCalculator.cs
└── Utils/
└── RandomUtils.cs
```
---

## 🚀 How to Run

### 1. Clone the repo
```bash
git clone https://github.com/<your-username>/PasswordGenerator.git
cd PasswordGenerator
dotnet build
dotnet run
```
---

## ⚙️ Features

Generates strong random passwords.

Includes lowercase, uppercase, digits, and symbols.

OOP architecture for cleaner code.

Calculates password entropy (bits of randomness).

---

## 🛠 Requirements

.NET 8 SDK

Works on Linux, Windows, and macOS.

---

## Example Output
Password Generator

Generated password: Zf!9gT2&kR@1xLq7
Entropy: 103.2 bits

