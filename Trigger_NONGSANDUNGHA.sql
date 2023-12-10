create trigger trigger_update_fullname on user_account
for update
as
begin
	update product_review 
	set review_owner = (select Concat(user_firstname,' ',user_lastname) from inserted where user_account_id = product_review.user_account_id)
	from product_review
	join deleted dl on product_review.user_account_id = dl.user_account_id
	
end

drop trigger trigger_update_fullname

go
create trigger trigger_update_point on user_order
for update
as 
begin
	update user_account
	set user_point = user_point + 1
	from user_account u inner join inserted i on u.user_account_id = i.user_account_id
	where i.is_delivered = N'Đã giao hàng'

	

	
end
go
create trigger trigger_update_rank on user_account
after update
as
begin
	if ( (select user_point from inserted ) > 1 )
	begin
		update user_account
		set user_member_tier = N'Bạc'
		from user_account u inner join inserted i on u.user_account_id = i.user_account_id
	end
	else if ( (select user_point from inserted ) > 5 )
	begin
	update user_account
		set user_member_tier = N'Vàng'
		from user_account u inner join inserted i on u.user_account_id = i.user_account_id
	end

end


go
Create Trigger UpdateTotalPrice
on user_order_product
for Insert,Update,Delete
as
begin
	update user_order
	set order_total_value = (select Sum(order_product_amount * i.product_price)+30 as N'Tổng Thành Tiền'
							from user_order_product u 
							inner join product i on u.product_id = i.product_id 
							inner join user_order us on us.user_order_id = u.user_order_id
							where us.user_order_id = (select user_order_id from inserted))
	where user_order.user_order_id = (select user_order_id from inserted)
	
	update user_order
		set order_total_value = (select Sum(order_product_amount * i.product_price)+30 as N'Tổng Thành Tiền'
							from user_order_product u 
							inner join product i on u.product_id = i.product_id 
							inner join user_order us on us.user_order_id = u.user_order_id
							where us.user_order_id = (select user_order_id from deleted))
	where user_order.user_order_id = (select user_order_id from deleted)
end