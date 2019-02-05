SELECT t.FirstLetter
  FROM 
  (
    SELECT LEFT(wd.FirstName, 1) AS FirstLetter
      FROM WizzardDeposits AS wd
     WHERE wd.DepositGroup = 'Troll Chest'
 ) AS t
 GROUP BY t.FirstLetter
 ORDER BY t.FirstLetter ASC