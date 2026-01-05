# TaskTracker

TaskTracker is a simple task management application built in C# using the .NET platform.  
It allows users to create, update, view, and delete tasks, helping them track work items and their completion status.

This project was intentionally built from scratch to reinforce core C# and .NET fundamentals, and then refactored to follow a cleaner, layered design.

---

## Purpose

The goal of this project was to:
- Recement foundational C# concepts (classes, collections, file I/O, JSON serialization)
- Practice clean project structure and separation of concerns
- Transition from a simple console-based application toward a more realistic backend architecture

The project started as a CLI application and has been refactored to use **Service** and **Repository** layers to prepare it for future improvements.

---

## Features

- Add new tasks with a name and description
- View all tasks
- View tasks by status (completed, unfinished, in progress)
- Update task descriptions
- Delete tasks
- Persist task data locally using a JSON file
- Automatic ID management for tasks

---

## Technologies Used

- **C#**
- **.NET**
- **System.Text.Json** for serialization
- **File I/O** for persistence
- Git & GitHub for version control

---
```md
## Project Structure
Models/ Task model
Services/ TaskManager (business logic)
Repositories/ TaskRepository (JSON persistence)
Program.cs Application entry point
tasks.json Runtime-generated task storage
```
## How to run

### Prerequisites
- .NET SDK installed (version 6.0 or later recommended)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/your-username/TaskTracker.git
```
2. Navigate to the project directory
```bash
cd BetterTaskTracker
```
3. Run the app
```bash
dotnet run
```
