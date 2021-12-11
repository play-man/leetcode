/*
A positive integer is magical if it is divisible by either a or b.

Given the three integers n, a, and b, return the nth magical number. Since the answer may be very large, return it modulo 109 + 7.

Constraints:

1 <= n <= 10^9
2 <= a, b <= 4 * 10^4
*/

var nthMagicalNumber = function (n, a, b) {
    let mod = 1000000007
    let start = Math.min(a, b)
    let end = start
    let temp = 1
    let lcdVal = lcd(a, b)
    while (temp < n) {
        end = end * 2
        temp = numberOfMagicalNumbers(end, a, b, lcdVal)
    }

    if (temp === n)
        return end - Math.min(end % a, end % b)

    let middle = 0
    while (start < end) {
        middle = Math.floor((start + end) / 2)
        temp = numberOfMagicalNumbers(middle, a, b, lcdVal)
        if (temp === n)
            break
        else if (temp < n)
            start = middle + 1
        else
            end = middle - 1
    }
    // Middle needs to be divisible by either a or b
    middle = middle - Math.min(middle % a, middle % b)

    return middle % mod
};

var numberOfMagicalNumbers = function (num, a, b, lcdVal) {
    return Math.floor(num / a) + Math.floor(num / b) - Math.floor(num / lcdVal)
}


var gcd = function (a, b) {
    if (!b) {
        return a;
    }

    return gcd(b, a % b);
}

var lcd = function (a, b) {
    return (a * b) / gcd(a, b);
}
