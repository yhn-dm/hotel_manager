# hotel_manager

# HotelManager

HotelManager est une application de bureau développée en C# (WinForms) permettant la **gestion complète d’un hôtel** : chambres, clients, réservations et tableau de bord.

---

## Aperçu de l'application



---

## Fonctionnalités

- Authentification utilisateur (inscription / connexion)
- Dashboard avec indicateurs clés (chambres libres, à nettoyer, clients arrivés)
- Gestion des clients (ajout, modification, suppression, historique)
- Gestion des chambres (numéro, type, tarif, statut)
- Gestion des réservations (création, édition, statut, filtre)
- Suivi de l'état des chambres (à nettoyer, propres, occupées)
- 🗃Historique associé pour chaque client et chaque chambre

---

## ⚙Installation

1. **Cloner le dépôt :**

```bash
git clone https://github.com/yhn-dm/hotel_manager.git
```
### Ouvrir le projet dans Visual Studio

1. Cloner ce dépôt ou télécharger le projet.
2. Ouvrir le fichier `.sln` avec **Visual Studio**.

---

### Configurer la base de données MySQL avec XAMPP

1. Démarrer **Apache** et **MySQL** via le panneau de contrôle XAMPP.

   ![XAMPP](./assets/xampp.png)

2. Accéder à **phpMyAdmin** : http://localhost/phpmyadmin  
3. Importer le script SQL pour créer la base de données :

```sql
CREATE DATABASE IF NOT EXISTS hotel_manager;
```
-- puis importer les tables (voir schéma plus bas)

---

## 🧱 Structure du projet

```bash
HotelManager/
│
├── DataAccess/         # Accès aux données MySQL (DAO)
├── Forms/              # Interfaces utilisateur (Formulaires)
├── Models/             # Classes métier (Chambre, Client, Réservation...)
├── Database/           # Connexion MySQL
├── Program.cs          # Point d'entrée de l'application
└── ...
```

### Exemple de connexion (Database/Database.cs)

```csharp
string connectionString = "server=localhost;user id=root;password=;database=hotel_manager;";
```

---

## 🗃️ Structure de la base de données

Le schéma relationnel est organisé comme suit :

- **utilisateurs** : pour l'authentification
- **clients**, **chambres**, et **reservations** liés à `utilisateur_id`

### Tables créées :

- `utilisateurs (id, username, password_hash)`
- `clients (id, nom, prenom, téléphone, email, utilisateur_id)`
- `chambres (id, numero, type, tarif, statut, utilisateur_id)`
- `reservations (id, id_client, id_chambre, date_arrivee, date_depart, statut, utilisateur_id)`

---

## 🔐 Système d’authentification

- Chaque utilisateur possède un espace privé sécurisé.
- Les données sont isolées par `utilisateur_id`.
- Les mots de passe sont **hashés** avant l'enregistrement.

---

## 💻 Technologies utilisées

- **C# / WinForms (.NET)**
- **MySQL** via **XAMPP**
- **Hashage de mot de passe**
- **Pattern DAO** pour la couche d’accès aux données

---

## 👤 Auteur

Développé par l'utilisateur **yhn-dm**

