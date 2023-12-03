-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 03, 2023 at 02:04 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ais`
--

-- --------------------------------------------------------

--
-- Table structure for table `grades`
--

CREATE TABLE `grades` (
  `gradeID` int(11) NOT NULL,
  `studentID` int(11) NOT NULL,
  `lecturerID` int(11) NOT NULL,
  `lectureID` int(11) NOT NULL,
  `grade_typeID` int(11) NOT NULL,
  `grade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `grades`
--

INSERT INTO `grades` (`gradeID`, `studentID`, `lecturerID`, `lectureID`, `grade_typeID`, `grade`) VALUES
(6, 22, 14, 10, 6, 10),
(7, 22, 14, 10, 4, 10),
(8, 22, 14, 11, 6, 10);

-- --------------------------------------------------------

--
-- Table structure for table `grade_type`
--

CREATE TABLE `grade_type` (
  `grade_type_ID` int(11) NOT NULL,
  `typeName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `grade_type`
--

INSERT INTO `grade_type` (`grade_type_ID`, `typeName`) VALUES
(1, 'Savarankiškas darbas'),
(2, 'Kontrolinis darbas'),
(3, 'Praktinis darbas'),
(4, 'Egzaminas'),
(5, 'Referatas'),
(6, 'Praktika');

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `groupID` int(11) NOT NULL,
  `groupName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`groupID`, `groupName`) VALUES
(1, 'PI19'),
(4, 'KS22'),
(16, 'PI25'),
(17, 'PI22B');

-- --------------------------------------------------------

--
-- Table structure for table `lecturer`
--

CREATE TABLE `lecturer` (
  `lecturerID` int(11) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lecturer`
--

INSERT INTO `lecturer` (`lecturerID`, `firstName`, `lastName`) VALUES
(12, 'Antanas', 'Baranauskas'),
(13, 'Juozas', 'Karvinskas'),
(14, 'Vaidas', 'Liubinas');

-- --------------------------------------------------------

--
-- Table structure for table `lecturergroups`
--

CREATE TABLE `lecturergroups` (
  `lecturerGroupID` int(11) NOT NULL,
  `lectureID` int(11) NOT NULL,
  `lecturerID` int(11) NOT NULL,
  `groupID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lecturergroups`
--

INSERT INTO `lecturergroups` (`lecturerGroupID`, `lectureID`, `lecturerID`, `groupID`) VALUES
(16, 10, 14, 17),
(17, 11, 14, 17);

-- --------------------------------------------------------

--
-- Table structure for table `lectures`
--

CREATE TABLE `lectures` (
  `lectureID` int(11) NOT NULL,
  `lectureName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lectures`
--

INSERT INTO `lectures` (`lectureID`, `lectureName`) VALUES
(10, 'Antroji programavimo praktika'),
(11, 'Objektinis programavimas');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `studentID` int(11) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `groupID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`studentID`, `firstName`, `lastName`, `groupID`) VALUES
(20, 'Emilis', 'Antinas', 1),
(21, 'Bobby', 'Duggardt', 16),
(22, 'Emilis', 'Borusas', 17);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `userID` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `DBuser` varchar(50) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `user_typeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `username`, `password`, `DBuser`, `firstName`, `lastName`, `user_typeID`) VALUES
(13, 'Emilis', 'Borusas1', 's046938', 'Emilis', 'Borusas', 1),
(25, 'Arnas', 'Petrauskas', 's180481', 'Arnas', 'Petrauskas', 2),
(27, 'Emilis', 'Antinas', 's371079', 'Emilis', 'Antinas', 3),
(29, 'Antanas', 'Baranauskas', 's579513', 'Antanas', 'Baranauskas', 2),
(30, 'Juozas', 'Karvinskas', 's526615', 'Juozas', 'Karvinskas', 2),
(31, 'Bobby', 'Duggardt', 's643165', 'Bobby', 'Duggardt', 3),
(32, 'Vaidas', 'Liubinas', 's316160', 'Vaidas', 'Liubinas', 2),
(33, 'Emilis', 'Borusas', 's917002', 'Emilis', 'Borusas', 3);

-- --------------------------------------------------------

--
-- Table structure for table `user_types`
--

CREATE TABLE `user_types` (
  `user_typeID` int(11) NOT NULL,
  `typeName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_types`
--

INSERT INTO `user_types` (`user_typeID`, `typeName`) VALUES
(1, 'Administratorius');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`gradeID`);

--
-- Indexes for table `grade_type`
--
ALTER TABLE `grade_type`
  ADD PRIMARY KEY (`grade_type_ID`);

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`groupID`);

--
-- Indexes for table `lecturer`
--
ALTER TABLE `lecturer`
  ADD PRIMARY KEY (`lecturerID`);

--
-- Indexes for table `lecturergroups`
--
ALTER TABLE `lecturergroups`
  ADD PRIMARY KEY (`lecturerGroupID`);

--
-- Indexes for table `lectures`
--
ALTER TABLE `lectures`
  ADD PRIMARY KEY (`lectureID`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD UNIQUE KEY `studentID` (`studentID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`);

--
-- Indexes for table `user_types`
--
ALTER TABLE `user_types`
  ADD PRIMARY KEY (`user_typeID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `grades`
--
ALTER TABLE `grades`
  MODIFY `gradeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `grade_type`
--
ALTER TABLE `grade_type`
  MODIFY `grade_type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `groups`
--
ALTER TABLE `groups`
  MODIFY `groupID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `lecturer`
--
ALTER TABLE `lecturer`
  MODIFY `lecturerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `lecturergroups`
--
ALTER TABLE `lecturergroups`
  MODIFY `lecturerGroupID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `lectures`
--
ALTER TABLE `lectures`
  MODIFY `lectureID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `studentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT for table `user_types`
--
ALTER TABLE `user_types`
  MODIFY `user_typeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
