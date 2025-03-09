🏆 Product Trial Master | ALTEN Bordeaux 🚀
🔹 Technical Assessment | Angular 18 + .NET 9 + SQLite

# *******Solution*******

Overview

# 🛒 Full-Stack E-Commerce Application  

This project is a **full-stack e-commerce application** where a user can **manage a list of products and a basket**.  

## 🏗️ Technology Stack  

### 🔧 Backend  
![.NET](https://img.shields.io/badge/Backend-.NET%209-blue?style=flat-square&logo=dotnet)  
Powered by **.NET 9** for a robust and scalable backend.  

### 💾 Database  
![SQLite](https://img.shields.io/badge/Database-SQLite-blue?style=flat-square&logo=sqlite)  
📌 When running the .NET Web API project, a **DBInitializer** provides:  
  - An initial list of products  
  - An initial admin user to log in with: `admin@admin.fr / Admin1234`  

### 🎨 Frontend  
![Angular](https://img.shields.io/badge/Frontend-Angular%2018-red?style=flat-square&logo=angular)  
Built with **Angular 18** for a dynamic and responsive UI.  


📂 Repository

Clone the project from GitHub:

git clone https://github.com/HOZEPHA/product-trial-master.git
cd front (for the Front-End Angular 18 SPA project) using vscode terminal
cd API (for the .Net Back-End API Project) using vscode terminal

✅ Prerequisites

1️⃣ Install Required Software

Ensure you have the following installed before running the application:

Visual Studio Code

.NET 9 SDK (Check with dotnet --version)

Node.js (Latest LTS Version) (Check with node --version)

SQLite (Check with sqlite3 --version)

2️⃣ VS Code Extensions

Install these extensions in VS Code for a smooth development experience:
alexcvzz.vscode-sqlite

angular.ng-template
github.copilot
github.copilot-chat
github.remotehub
ms-dotnettools.csdevkit
ms-dotnettools.csharp
ms-dotnettools.vscode-dotnet-runtime
ms-vscode.azure-repos
ms-vscode.remote-repositories
patcx.vscode-nuget-gallery
pkief.material-icon-theme

C# – Required for .NET development

Angular Essentials – Recommended for Angular development

SQLite – Helps manage SQLite database

🚀 Setup Instructions

Backend: .NET 9 API Setup

Navigate to the backend folder using the terminal:

cd API

Restore dependencies:

dotnet restore

Apply database migrations (if needed):

dotnet ef database update

Run the backend server:

dotnet run

The backend should now be running at:http://localhost:5000 (or the port defined in launchSettings.json).

Frontend: Angular 18 Setup

Navigate to the frontend folder using the terminal:

cd front

Install dependencies:

npm install

Start the Angular development server:

ng serve

The frontend should now be running at:http://localhost:4200

🎯 Running Backend & Frontend Together

To run both the backend and frontend simultaneously:

Open two separate terminals in VS Code:

Terminal 1: Run the backend

cd API
dotnet run (or dotnet watch run to enable the hot realod -- which is not perfect )

Terminal 2: Run the frontend

cd front
ng serve (shortcut ng s --o)

🛠 Database Configuration (SQLite)

The project uses SQLite as the database.

The default configuration is in appsettings.json inside the backend folder.

If you need to apply database migrations:

dotnet ef database update

To view the database, open it using a SQLite client or the VS Code SQLite Extension.

📜 License

This project is licensed under the MIT License.

💡 Contributions

Feel free to contribute by submitting a pull request or reporting issues.

🏆 Author

Developed by [Hozepha]GitHub: https://github.com/HOZEPHA in collaboration with [ALTEN](all rights reserved)


****************************************Consignes*******************************
# Consignes

- Vous êtes développeur front-end : vous devez réaliser les consignes décrites dans le chapitre [Front-end](#Front-end)

- Vous êtes développeur back-end : vous devez réaliser les consignes décrites dans le chapitre [Back-end](#Back-end) (*)

- Vous êtes développeur full-stack : vous devez réaliser les consignes décrites dans le chapitre [Front-end](#Front-end) et le chapitre [Back-end](#Back-end) (*)

(*) Afin de tester votre API, veuillez proposer une stratégie de test appropriée.

## Front-end

Le site de e-commerce d'Alten a besoin de s'enrichir de nouvelles fonctionnalités.

### Partie 1 : Shop

- Afficher toutes les informations pertinentes d'un produit sur la liste
- Permettre d'ajouter un produit au panier depuis la liste 
- Permettre de supprimer un produit du panier
- Afficher un badge indiquant la quantité de produits dans le panier
- Permettre de visualiser la liste des produits qui composent le panier.

### Partie 2

- Créer un nouveau point de menu dans la barre latérale ("Contact")
- Créer une page "Contact" affichant un formulaire
- Le formulaire doit permettre de saisir son email, un message et de cliquer sur "Envoyer"
- Email et message doivent être obligatoirement remplis, message doit être inférieur à 300 caractères.
- Quand le message a été envoyé, afficher un message à l'utilisateur : "Demande de contact envoyée avec succès".

### Bonus : 

- Ajouter un système de pagination et/ou de filtrage sur la liste des produits
- On doit pouvoir visualiser et ajuster la quantité des produits depuis la liste et depuis le panier 

## Back-end

### Partie 1

Développer un back-end permettant la gestion de produits définis plus bas.
Vous pouvez utiliser la technologie de votre choix parmi la liste suivante :

- Node.js/Express
- Java/Spring Boot
- C#/.net Core
- PHP/Symphony : Utilisation d'API Platform interdite


Le back-end doit gérer les API suivantes : 

| Resource           | POST                  | GET                            | PATCH                                    | PUT | DELETE           |
| ------------------ | --------------------- | ------------------------------ | ---------------------------------------- | --- | ---------------- |
| **/products**      | Create a new product  | Retrieve all products          | X                                        | X   |     X            |
| **/products/:id**  | X                     | Retrieve details for product 1 | Update details of product 1 if it exists | X   | Remove product 1 |

Un produit a les caractéristiques suivantes : 

``` typescript
class Product {
  id: number;
  code: string;
  name: string;
  description: string;
  image: string;
  category: string;
  price: number;
  quantity: number;
  internalReference: string;
  shellId: number;
  inventoryStatus: "INSTOCK" | "LOWSTOCK" | "OUTOFSTOCK";
  rating: number;
  createdAt: number;
  updatedAt: number;
}
```

Le back-end créé doit pouvoir gérer les produits dans une base de données SQL/NoSQL ou dans un fichier json.

### Partie 2

- Imposer à l'utilisateur de se connecter pour accéder à l'API.
  La connexion doit être gérée en utilisant un token JWT.  
  Deux routes devront être créées :
  * [POST] /account -> Permet de créer un nouveau compte pour un utilisateur avec les informations fournies par la requête.   
    Payload attendu : 
    ```
    {
      username: string,
      firstname: string,
      email: string,
      password: string
    }
    ```
  * [POST] /token -> Permet de se connecter à l'application.  
    Payload attendu :  
    ```
    {
      email: string,
      password: string
    }
    ```
    Une vérification devra être effectuée parmi tout les utilisateurs de l'application afin de connecter celui qui correspond aux infos fournies. Un token JWT sera renvoyé en retour de la reqûete.
- Faire en sorte que seul l'utilisateur ayant le mail "admin@admin.com" puisse ajouter, modifier ou supprimer des produits. Une solution simple et générique devra être utilisée. Il n'est pas nécessaire de mettre en place une gestion des accès basée sur les rôles.
- Ajouter la possibilité pour un utilisateur de gérer un panier d'achat pouvant contenir des produits.
- Ajouter la possibilité pour un utilisateur de gérer une liste d'envie pouvant contenir des produits.

## Bonus

Vous pouvez ajouter des tests Postman ou Swagger pour valider votre API
