using NUnit.Framework;
using System.Collections.Generic;

namespace DataStructures.XYCoordinates {
	[TestFixture]
	class NodeTests {
		private Node node;

		[SetUp]
		public void Setup() {
			this.node = new Node {
				x = 1,
				y = -2
			};
		}
		
		[Test]
		[Category( "IEquatable" )]
		public void EqualNodes() {
			Node sameNode = new Node {
				x = this.node.x,
				y = this.node.y
			};

			Assert.AreEqual(
				this.node,
				sameNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void EqualNodesWithEqualOp() {
			Node sameNode = new Node {
				x = this.node.x,
				y = this.node.y
			};

			Assert.IsTrue(
				this.node == sameNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void EqualNodesWithNotEqualOp() {
			Node sameNode = new Node {
				x = this.node.x,
				y = this.node.y
			};

			Assert.IsFalse(
				this.node != sameNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void NotEqualNodes() {
			Node notSameNode = new Node {
				x = 2,
				y = 3
			};

			Assert.AreNotEqual(
				this.node,
				notSameNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void NotEqualNodesWithEqualOp() {
			Node notSameNode = new Node {
				x = 2,
				y = 3
			};

			Assert.IsFalse(
				this.node == notSameNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void NotEqualNodesWithNotEqualOp() {
			Node notSameNode = new Node {
				x = 2,
				y = 3
			};

			Assert.IsTrue(
				this.node != notSameNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToString() {
			string text = "Not a node.";

			Assert.IsFalse(
				this.node.Equals(
					text
				)
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToNull() {
			Node nullNode = null;

			Assert.IsFalse(
				this.node.Equals(
					nullNode
				)
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToNullWithEqualOp() {
			Node nullNode = null;

			Assert.IsFalse(
				this.node == nullNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToNullWithNotEqualOp() {
			Node nullNode = null;

			Assert.IsTrue(
				this.node != nullNode
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareHashCodeOfSameNodes() {
			Node sameNode = new Node {
				x = this.node.x,
				y = this.node.y
			};

			Assert.AreEqual(
				this.node.GetHashCode(),
				sameNode.GetHashCode()
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareHashCodeOfTwoDifferentNodes() {
			Node notSameNode = new Node {
				x = 2,
				y = 3
			};

			Assert.AreNotEqual(
				this.node.GetHashCode(),
				notSameNode.GetHashCode()
			);
		}

		[Test]
		public void ConvertToString() {
			Assert.AreEqual(
				"( "
				+ this.node.x
				+ ", "
				+ this.node.y
				+ " )"
				,
				this.node.ToString()
			);
		}

	}
}
