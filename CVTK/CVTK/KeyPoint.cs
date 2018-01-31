using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Flann;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Linq;
namespace CVTK
{
    public class KeyPoint
    {
        public static MKeyPoint[] Process(string file)
        {
           
            using (Mat modelImage = CvInvoke.Imread(file, ImreadModes.Color))
            using (Mat observedImage = CvInvoke.Imread(file, ImreadModes.Color))
            {
                var result = Draw(modelImage, observedImage);
                return result;
            }
        }

        private static void FindMatch(Mat modelImage, Mat observedImage, out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints, VectorOfVectorOfDMatch matches)
        {

            modelKeyPoints = new VectorOfKeyPoint();
            observedKeyPoints = new VectorOfKeyPoint();

            using (UMat uModelImage = modelImage.GetUMat(AccessType.Read))
            using (UMat uObservedImage = observedImage.GetUMat(AccessType.Read))
            {
                KAZE featureDetector = new KAZE();
                Mat modelDescriptors = new Mat();
                featureDetector.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false);
            }
        }

        public static MKeyPoint[] Draw(Mat modelImage, Mat observedImage)
        {
            VectorOfKeyPoint modelKeyPoints;
            VectorOfKeyPoint observedKeyPoints;
            using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
            {
                FindMatch(modelImage, observedImage, out modelKeyPoints, out observedKeyPoints, matches);
                var keyarr =modelKeyPoints.ToArray();
                return keyarr;
            }
        }
    }
}


