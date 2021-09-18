select [user].profile,[user].name,[user].phone_no,[user].email,job.title,bids.amount,contract.finish_date,contract.payment_status
from [user]
inner join job on [user].user_Id=job.empr_id
inner join bids on job.job_id = bids.job_id
inner join contract on bids.bids_id = contract.bids_id
where bids.empe_id = 2