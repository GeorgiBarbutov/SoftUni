SELECT SUM(t.Differences)
  FROM
       (
	   SELECT [Host].DepositAmount - 
			  (
			  SELECT [Guest].DepositAmount	    
				FROM WizzardDeposits AS [Guest]
			   WHERE [Host].Id = [Guest].Id - 1
			  ) AS [Differences]	   
	     FROM WizzardDeposits AS [Host]
       ) AS t