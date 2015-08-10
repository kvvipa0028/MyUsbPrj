
close all;
clear all;

A = imread('a.jpg');
O = imread('o.jpg');

figure, imshow(A,[]);

hist = zeros(1,256);
B = zeros(240,320,3);
for i=1:240
    for j=1:320
        hist(1,A(i,j)+1) = hist(1,A(i,j)+1) + 1;
        B(i,j,1) = A(i,j);B(i,j,2) = A(i,j);B(i,j,3) = A(i,j);
    end
end
ohist = histgram(A);
figure, bar(ohist);



