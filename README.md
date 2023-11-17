<div align="center">
	<h1 align="center">Eternal</h1>

  **Eternal** is a distributed, scalable, modular server framework for a popular mushroom based mmorpg game.
  This project is currently very much a **Work in Progress** and will always remain **Open Source**. 

  <img src="https://img.shields.io/github/stars/Razen21/Eternal?style=for-the-badge&logo=appveyor" />
  <img src="https://img.shields.io/github/forks/Razen21/Eternal?style=for-the-badge&logo=appveyor" />
  <img src="https://img.shields.io/github/issues/Razen21/Eternal?style=for-the-badge&logo=appveyor" />
  <img src="https://img.shields.io/github/license/Razen21/Eternal?style=for-the-badge&logo=appveyor" />
  <a href="https://visitorbadge.io/status?path=https%3A%2F%2Fgithub.com%2FRazen21%Eternal">
    <img src="https://api.visitorbadge.io/api/visitors?path=https%3A%2F%2Fgithub.com%2FRazen21%Eternal&countColor=%2337d67a" />
  </a>

</div>


## Table of Contents
- [About](#about)
- [Features](#features)
- [Contributing](#contributing)
- [Tech Stack](#techstack)


## About
This project was started as an education experience for myself aswell as to try and fill the void of reliable open source server frameworks that exist in this community.

## Contributing
**Currently not accepting contribution in the early stages of the project to maintain structure.**

If you wish to contribute to the project please fork the repository and push your changes to a feature branch. Create a pull request with those changes and they will be reviewed as soon as possible.

## Features
**Eternal** offers a semi-modular plug and play experience. The goal of the project is to provide a clean server framework other users can fork and customize.

- The goal is to maintian as up-to-date as possible. The current targeted version is **v246.1.1**.
- **Rich Documentation** alongside a server framework, this project aims to provide precise documentation not only about the project but server framework development in general. This is achieved with the use of **Github Docs**.
- **Tools** to aid in the development of the server, including an **Admin Control Panel** aswell as seemless data generation.
- Multitude of libraries that will hosted on **Nuget** to make development easier for other projects.

## TechStack
**Eternal** is designed around distributed microservices making use of **.NET Core 8+** and **ASP.NET API's**.
- **Docker** for service containerization.
- **Docker-Compose** for local container orchestration. (**Kubernetes** available in the future.)
- **Dapr** for cross service communication including service invocation.
- **RabbitMQ** combined with **Dapr** for seemless pub/sub events.
- **MongoDB** for a distributed and efficient data storage.
- **Redis** for a fast data cache.

More to come in the future.

