-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Jeu 24 Mai 2018 à 03:19
-- Version du serveur :  5.6.20-log
-- Version de PHP :  5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `produits`
--

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE IF NOT EXISTS `produits` (
  `ID` int(11) NOT NULL,
  `PRIX` double NOT NULL,
  `NUMERO` varchar(255) NOT NULL,
  `NOMPRODUIT` varchar(255) NOT NULL,
  `QUANTITE` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Contenu de la table `produits`
--

INSERT INTO `produits` (`ID`, `PRIX`, `NUMERO`, `NOMPRODUIT`, `QUANTITE`) VALUES
(1, 12, '143', 'Biere', 100),
(2, 10, '4534', 'Banane', 50),
(3, 2, '54312', 'Soupe', 200),
(4, 20, '654', 'Dinde', 15),
(5, 12, '123542', 'Vin', 300);

--
-- Index pour les tables exportées
--

--
-- Index pour la table `produits`
--
ALTER TABLE `produits`
 ADD PRIMARY KEY (`ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
