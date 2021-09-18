select [user].name from [user] 
inner join bids on [user].user_Id=bids.empe_id
inner join job on bids.job_id = job.job_id
where job.empr_id=2
 