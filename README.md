# Stock-BuyCodeChallenge
Stock&amp;BuyCodeChallenge

This working solution is tested with the tree hierarchy with multiple nested levels.

Sample data used to test it is a tree structure up to nested level 3 but please feel free to add more nesting to test the accuracy of the code.

This code calculates the number of bundles  that can be created using the sub-bundles. 

Related DB schema diagram and  EF classes are included in the solution but the EF classes are not fully utilized due to time constraints.

For any clarification or discussion  over the solution, please schedule a call. 

This solution checks at each sub-bundle level how many parent products can be created using the parts required and the available inventory

Based on the calculation it will pick the minimum count of bundles  that can be created based on inventory and requirements from the sub-bundles 

Then update the inventory of the parent bundle with the min bundles that can be created using the sub-bundles

This process goes in recursion till the final bundle is not reached.

In case of any shortage of inventory program will raise an exception   
