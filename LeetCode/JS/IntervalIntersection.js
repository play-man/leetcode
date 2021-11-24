/*You are given two lists of closed intervals, firstList and secondList, 
where firstList[i] = [starti, endi] and secondList[j] = [startj, endj]. 
Each list of intervals is pairwise disjoint and in sorted order.

Return the intersection of these two interval lists.

A closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.

The intersection of two closed intervals is a set of real numbers that are either empty or represented as a closed interval. 
For example, the intersection of [1, 3] and [2, 4] is [2, 3].

Constraints:

0 <= firstList.length, secondList.length <= 1000
firstList.length + secondList.length >= 1
0 <= start_i < end_i <= 109
end_i < start_i+1
0 <= start_j < end_j <= 109
end_j < start_j+1*/

var intervalIntersection = function (firstList, secondList) {
    let firstLength = firstList.length;
    let secondLength = secondList.length;
    let result = Array();
    let firstAhead = 0;
    let lastBehind = -1;

    if (firstLength == 0 || secondLength == 0) return result;

    for (let i = 0; i < firstLength; ++i) {
        while ((lastBehind < secondLength - 1) && secondList[lastBehind + 1][1] < firstList[i][0])
            lastBehind++;
        while ((firstAhead < secondLength) && secondList[firstAhead][0] <= firstList[i][1])
            firstAhead++;

        for (let j = lastBehind + 1; j <= firstAhead - 1; ++j) {
            let intersection = singleIntervalIntersection(firstList[i], secondList[j])
            if (intersection[0] >= 0)
                result.push(intersection);
        }
    }
    return result;
};

var singleIntervalIntersection = function (firstInterval, secondInterval) {
    if (firstInterval[1] < secondInterval[0])
        return [-1, -1];
    else {
        if (secondInterval[1] < firstInterval[0])
            return [-1, -1];
        else if (firstInterval[0] < secondInterval[0])
            return [secondInterval[0], Math.min(secondInterval[1], firstInterval[1])];
        else
            return [firstInterval[0], Math.min(secondInterval[1], firstInterval[1])];
    }
}