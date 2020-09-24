Chocolate 
	string name
    int cacaoAmount
 	int milkAmount
 	List<Filling> filling
 	double CalculatePrice()

Order
	string message
	Address adress
	bool confirmed
 	Package package
 	List<Chocolate > items
	Donation donation
	bool Confirm()
bool Cancel()

Customer
	int id
 	string name
 	List<Order> orders


