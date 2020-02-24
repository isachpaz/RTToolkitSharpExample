using System;
using System.Linq;
using RTToolkitSharp.DoseVolumeHistogram.Factory;
using RTToolkitSharp.DoseVolumeHistogram.Helpers;
using RTToolkitSharp.RTQuantities.Quantities.Dose;
using RTToolkitSharp.RTQuantities.Quantities.Volume;
using Xunit;

namespace RTToolkitSharpExamples
{
    public class DVH_Tests
    {
        [Fact]
        public void DDVH_ctor_Test()
        {
            int numberOfVoxels = 100;
            var doses = PhysicalDoseValue
                .Range(start: 0, stop: 100, step: 1, bIncludeLastValue: true, unit: PhysicalDoseValue.DoseUnit.GY)
                .Take(numberOfVoxels);
            var volumes = Enumerable.Repeat(VolumeValue.New(8, VolumeValue.VolumeUnit.MM3), numberOfVoxels);
            var tuples = doses.Zip(volumes, (dose, volume) => Tuple.Create(dose, volume));

            var dvpoints = tuples.ToDVPoints();

            var settings = DVHSettingsFactory<PhysicalDoseValue>.FromMinMax(min: 0, max: 200, numberOfBins: 200,
                doseUnit: PhysicalDoseValue.DoseUnit.GY, volumeUnit: VolumeValue.VolumeUnit.MM3);
            var ddvh = DVHFactory<PhysicalDoseValue>.FromDifferentialDoseVolumePairs(type: DVHType.DIFFERENTIAL,
                settings: settings, pairs: dvpoints);
        }

    }
}