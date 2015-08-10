function Ohist = histgram(InImage)
%HISTGRAM Summary of this function goes here
%   Detailed explanation goes here
[width,height] = size(InImage);
Ohist = zeros(1,256);
for i = 1:width
    for j=1:height
        Ohist(1,InImage(i,j)+1) = Ohist(1,InImage(i,j)+1) + 1;
    end
end
end

