Michael Blake
05/12/2014

Comments;
Need to output something? CSV, quick Excel Graph?
Should we store the data somewhere?
What if the app was run twice on the same day?

Approach;
Factor out what is there so we can test it using VS2013 and R#
Add option /s args so the console can be run via a script if required.
Review the existing requirements and add tests.
First problem, is all the products are done of a Name string so should we try and create objects as this will be faster nice to manage.
e.g. new AgedBrie() { Sell = 1, Quality = 2 } then use if (item is AgedBrie) ?
For now, I've kept the strings as the Item and Items are readonly. Maybe think about talking to the goblin in the corner about this?

