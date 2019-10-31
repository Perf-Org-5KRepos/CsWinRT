using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using WinRT;

using WF = Windows.Foundation;
using WFC = Windows.Foundation.Collections;
using WFN = Windows.Foundation.Numerics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Numerics;

using TestComp;

namespace UnitTest
{
    using A = IIterable<IStringable>;
    using B = IKeyValuePair<string, IAsyncOperationWithProgress</*A*/IIterable<IStringable>, float>>;

    public class TestGuids
    {
        private static void AssertGuid<T>(string expected)
        {
            var actual = GuidGenerator.CreateIID(typeof(T));
            Assert.Equal(actual, new Guid(expected));
        }

        [Fact]
        public void TestGenerics()
        {
            // Ensure every generic instance has a unique PIID
            Assert.NotEqual(IMap<bool, string>.Vftbl.PIID, IMap<string, bool>.Vftbl.PIID);

            AssertGuid<IStringable>("96369f54-8eb6-48f0-abce-c1b211e627c3"); 

            // Generated Windows.Foundation GUIDs
            AssertGuid<IAsyncActionWithProgress<A>>("dd725452-2da3-5103-9c7d-22ee9bb14ad3");
            AssertGuid<IAsyncOperationWithProgress<A, B>>("94645425-b9e5-5b91-b509-8da4df6a8916");
            AssertGuid<IAsyncOperation<A>>("2bd35ee6-72d9-5c5d-9827-05ebb81487ab");
            AssertGuid<IReferenceArray<A>>("4a33fe03-e8b9-5346-a124-5449913eca57");
            AssertGuid<IReference<A>>("f9e4006c-6e8c-56df-811c-61f9990ebfb0");
            AssertGuid<AsyncActionProgressHandler<A>>("c261d8d0-71ba-5f38-a239-872342253a18");
            AssertGuid<AsyncActionWithProgressCompletedHandler<A>>("9a0d211c-0374-5d23-9e15-eaa3570fae63");
            AssertGuid<AsyncOperationCompletedHandler<A>>("9d534225-231f-55e7-a6d0-6c938e2d9160");
            AssertGuid<AsyncOperationProgressHandler<A, B>>("264f1e0c-abe4-590b-9d37-e1cc118ecc75");
            AssertGuid<AsyncOperationWithProgressCompletedHandler<A, B>>("c2d078d8-ac47-55ab-83e8-123b2be5bc5a");
            AssertGuid<WF.EventHandler<A>>("fa0b7d80-7efa-52df-9b69-0574ce57ada4");
            AssertGuid<TypedEventHandler<A, B>>("edb31843-b4cf-56eb-925a-d4d0ce97a08d");

            // Generated Windows.Foundation.Collections GUIDs
            AssertGuid<IIterable<A>>("96565eb9-a692-59c8-bcb5-647cde4e6c4d");
            AssertGuid<IIterator<A>>("3c9b1e27-8357-590b-8828-6e917f172390");
            AssertGuid<IKeyValuePair<A, B>>("89336cd9-8b66-50a7-9759-eb88ccb2e1fe");
            AssertGuid<IMapChangedEventArgs<A>>("e1aa5138-12bd-51a1-8558-698dfd070abe");
            AssertGuid<IMapView<A, B>>("b78f0653-fa89-59cf-ba95-726938aae666");
            AssertGuid<IMap<A, B>>("9962cd50-09d5-5c46-b1e1-3c679c1c8fae");
            AssertGuid<IObservableMap<A, B>>("75f99e2a-137e-537e-a5b1-0b5a6245fc02");
            AssertGuid<IObservableVector<A>>("d24c289f-2341-5128-aaa1-292dd0dc1950");
            AssertGuid<IVectorView<A>>("5f07498b-8e14-556e-9d2e-2e98d5615da9");
            AssertGuid<IVector<A>>("0e3f106f-a266-50a1-8043-c90fcf3844f6");
            AssertGuid<MapChangedEventHandler<A, B>>("19046f0b-cf81-5dec-bbb2-7cc250da8b8b");
            AssertGuid<VectorChangedEventHandler<A>>("a1e9acd7-e4df-5a79-aefa-de07934ab0fb");

            // Generated primitive GUIDs
            AssertGuid<IReference<bool>>("3c00fd60-2950-5939-a21a-2d12c5a01b8a");
            AssertGuid<IReference<sbyte>>("95500129-fbf6-5afc-89df-70642d741990");
            AssertGuid<IReference<Int16>>("6ec9e41b-6709-5647-9918-a1270110fc4e");
            AssertGuid<IReference<Int32>>("548cefbd-bc8a-5fa0-8df2-957440fc8bf4");
            AssertGuid<IReference<Int64>>("4dda9e24-e69f-5c6a-a0a6-93427365af2a");
            AssertGuid<IReference<byte>>("e5198cc8-2873-55f5-b0a1-84ff9e4aad62");
            AssertGuid<IReference<UInt16>>("5ab7d2c3-6b62-5e71-a4b6-2d49c4f238fd");
            AssertGuid<IReference<UInt32>>("513ef3af-e784-5325-a91e-97c2b8111cf3");
            AssertGuid<IReference<UInt64>>("6755e376-53bb-568b-a11d-17239868309e");
            AssertGuid<IReference<float>>("719cc2ba-3e76-5def-9f1a-38d85a145ea8");
            AssertGuid<IReference<double>>("2f2d6c29-5473-5f3e-92e7-96572bb990e2");
            AssertGuid<IReference<char>>("fb393ef3-bbac-5bd5-9144-84f23576f415");
            AssertGuid<IReference<Guid>>("7d50f649-632c-51f9-849a-ee49428933ea");
            AssertGuid<IReference<HResult>>("6ff27a1e-4b6a-59b7-b2c3-d1f2ee474593");
            AssertGuid<IReference<string>>("fd416dfb-2a07-52eb-aae3-dfce14116c05");
            //AssertGuid<IReference<event_token>>("a9b18291-ce2a-5dae-8a23-b7f7388416db");
            AssertGuid<IReference<WF.TimeSpan>>("604d0c4c-91de-5c2a-935f-362f13eaf800");
            AssertGuid<IReference<WF.DateTime>>("5541d8a7-497c-5aa4-86fc-7713adbf2a2c");
            AssertGuid<IReference<Point>>("84f14c22-a00a-5272-8d3d-82112e66df00");
            AssertGuid<IReference<Rect>>("80423f11-054f-5eac-afd3-63b6ce15e77b");
            AssertGuid<IReference<Size>>("61723086-8e53-5276-9f36-2a4bb93e2b75");

            // Enums, structs, IInspectable, classes, and delegates
            AssertGuid<IReference<PropertyType>>("ecebde54-fac0-5aeb-9ba9-9e1fe17e31d5");
            AssertGuid<IReference<Point>>("84f14c22-a00a-5272-8d3d-82112e66df00");
            AssertGuid<IVector<IInspectable>>("b32bdca4-5e52-5b27-bc5d-d66a1a268c2a");
            AssertGuid<IVector<WF.Uri>>("0d82bd8d-fe62-5d67-a7b9-7886dd75bc4e");
            AssertGuid<IVector<AsyncActionCompletedHandler>>("5dafe591-86dc-59aa-bfda-07f5d59fc708");
        }
    }

    
    public class TestComponent
    {
        public Class TestObject { get; private set; }

        public TestComponent()
        {
            TestObject = new Class();
        }

        [Fact]
        public void TestUri()
        {
            var base_uri = "https://github.com";
            var relative_uri = "microsoft/CsWinRT";
            var full_uri = base_uri + "/" + relative_uri;

            var uri1 = new WF.Uri(full_uri);
            var str1 = uri1.ToString();
            Assert.Equal(full_uri, str1);
            
            var uri2 = new WF.Uri(base_uri, relative_uri);
            var str2 = uri2.ToString();
            Assert.Equal(full_uri, str2);

            Assert.True(uri1.Equals(uri2));
        }

        [Fact]
        public void TestFactories()
        {
            var cls1 = new Class();
            
            var cls2 = new Class(42);
            Assert.Equal(42, cls2.IntProperty);

            var cls3 = new Class(42, "foo");
            Assert.Equal(42, cls3.IntProperty);
            Assert.Equal("foo", cls3.StringProperty);
        }

        [Fact]
        public void TestStaticMembers()
        {
            Class.StaticIntProperty = 42;
            Assert.Equal(42, Class.StaticIntProperty);

            Class.StaticStringProperty = "foo";
            Assert.Equal("foo", Class.StaticStringProperty);
        }

        [Fact]
        public void TestStaticClass()
        {
            Assert.Equal(0, StaticClass.NumClasses);
            var obj = StaticClass.MakeClass();
            Assert.Equal(1, StaticClass.NumClasses);
        }

        [Fact]
        public void TestInterfaces()
        {
            var expected = "hello";
            TestObject.StringProperty = expected;

            // projected wrapper
            Assert.Equal(expected, TestObject.ToString());

            // implicit cast 
            var str = (IStringable)TestObject;
            Assert.Equal(expected, str.ToString());

            // explicit cast
            IStringable str2 = TestObject.As<IStringable>();
            Assert.Equal(expected, str2.ToString());

            // TODO: 'is' and 'as' operators - reconsider interface inheritance
        }

        [Fact]
        public void TestPrimitives()
        {
            var test_int = 21;
            TestObject.IntPropertyChanged += (IInspectable sender, Int32 value) =>
            {
                var c = Class.FromNative(sender.NativePtr);
                Assert.Equal(value, test_int);
            };
            TestObject.IntProperty = test_int;
        }

        [Fact]
        public void TestStrings()
        {
            string test_string = "x";
            string test_string2 = "y";

            var href = new WinRT.HStringReference(test_string);

            // In hstring from managed->native implicitly creates hstring reference 
            TestObject.StringProperty = test_string;

            // Out hstring from native->managed only creates System.String on demand
            var sp = TestObject.StringProperty;
            Assert.Equal(sp, test_string);

            // Out hstring from managed->native always creates HString from System.String
            TestObject.CallForString(() => test_string2);
            Assert.Equal(TestObject.StringProperty, test_string2);

            // In hstring from native->managed only creates System.String on demand
            TestObject.StringPropertyChanged += (Class sender, WinRT.HString value) => sender.StringProperty2 = value;
            TestObject.RaiseStringChanged();
            Assert.Equal(TestObject.StringProperty2, test_string2);
        }
    }
}