SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits AS wd
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup