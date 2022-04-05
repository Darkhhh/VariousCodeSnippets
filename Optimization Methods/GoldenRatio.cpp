#include <iostream>
#include <cmath>

using namespace std;

const double goldenRatio = (3 - sqrt(5)) / 2;

double Function(double argument){
    return pow(argument,2) + 4 * argument + 5;
}

double GoldenRatio(double a, double b, double eps){
    double yTemp = 0, zTemp = 0;
    double fY = 0, fZ = 0;
    bool end = false;

    int iter = 0;
    yTemp = a + goldenRatio * (b - a);
    zTemp = a + b - yTemp;
    while(!end){
        iter++;
        if(Function(yTemp) <= Function(zTemp)){
            b = zTemp;
            zTemp = yTemp;
            yTemp = a + b - zTemp;
        }
        else{
            a = yTemp;
            yTemp = zTemp;
            zTemp = a + b - yTemp;
        }

        if(abs(a - b) < eps){
            end = true;
        }
    }
    cout << iter << endl;
    return (a + b) / 2;
}
int main() {
    double a = -4, b = 6;
    double eps = 0.25;
    cout << GoldenRatio(a,b,eps) << endl;
}
