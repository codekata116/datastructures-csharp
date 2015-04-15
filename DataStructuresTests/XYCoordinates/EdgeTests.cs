using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructures.XYCoordinates {
	
	[TestFixture]
	class EdgeTests {
		private Node nodeA;
		private Node nodeB;
		private Node nodeC;
		private Node nodeD;

		private Edge edgeAB;
		private Edge edgeAC;
		private Edge edgeAD;
		private Edge edgeBD;

		[SetUp]
		public void Setup() {
			this.nodeA = new Node {
				x = 1,
				y = 3
			};

			this.nodeB = new Node {
				x = 1,
				y = -3
			};

			this.nodeC = new Node {
				x = -1,
				y = 3
			};

			this.nodeD = new Node {
				x = -1,
				y = -3
			};

			this.edgeAB = new Edge {
				StartNode = this.nodeA,
				EndNode = this.nodeB
				// weight = 6.0
			};

			this.edgeAC = new Edge {
				StartNode = this.nodeA,
				EndNode = this.nodeC
				// weight = 2.0
			};

			this.edgeAD = new Edge {
				StartNode = this.nodeA,
				EndNode = this.nodeD
				// weight ~= 6.3
			};

			this.edgeBD = new Edge {
				StartNode = this.nodeB,
				EndNode = this.nodeD
				// weight = 2.0
			};
		}

		[Test]
		[Category( "Weight" )]
		public void DifferentNodes() {
			Assert.AreEqual(
				6.0,
				this.edgeAB.Weight
			);
		}

		[Test]
		[Category( "Weight" )]
		public void SameNode() {
			Node anotherNodeA = new Node {
				x = this.nodeA.x,
				y = this.nodeA.y
			};

			Edge noWeightEdge = new Edge {
				StartNode = this.nodeA,
				EndNode = anotherNodeA
			};

			Assert.AreEqual(
				0,
				noWeightEdge.Weight
			);
		}

		[Test]
		[Category( "Weight" )]
		public void TwoPositiveXValues() {
			Assert.AreEqual(
				6.0,
				this.edgeAB.Weight
			);
		}

		[Test]
		[Category( "Weight" )]
		public void TwoPositiveYValues() {
			Assert.AreEqual(
				2.0,
				this.edgeAC.Weight
			);
		}

		[Test]
		[Category( "Weight" )]
		public void TwoNegativeXValues() {
			Assert.AreEqual(
				6.0,
				this.edgeAB.Weight
			);
		}

		[Test]
		[Category( "Weight" )]
		public void TwoNegativeYValues() {
			Assert.AreEqual(
				2.0,
				this.edgeBD.Weight
			);
		}

		[Test]
		[Category( "CompareTo" )]
		[ExpectedException( typeof( ArgumentException ) )]
		public void NotEdgeTest() {
			string text = "Not an Edge";

			this.edgeAB.CompareTo(
				text
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareSameNodesEdges() {
			Edge sameEdge = new Edge {
				StartNode = new Node {
					x = this.nodeA.x,
					y = this.nodeA.y
				},
				EndNode = new Node {
					x = this.nodeB.x,
					y = this.nodeB.y
				}
			};

			Assert.AreEqual(
				0,
				this.edgeAB.CompareTo( sameEdge )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareSameWeightEdgesDifferentStartNodeX() {
			Node startNodeA = new Node {
				x = 7,
				y = 12
			};

			Node startNodeB = new Node {
				x = -7,
				y = 12
			};

			Node endNode = new Node {
				x = 0,
				y = -9
			};

			Edge edgeA = new Edge {
				StartNode = startNodeA,
				EndNode = endNode
			};

			Edge edgeB = new Edge {
				StartNode = startNodeB,
				EndNode = endNode
			};

			Assert.AreEqual(
				1,
				edgeA.CompareTo( edgeB )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareSameWeightEdgesDifferentStartNodeY() {
			Node startNodeA = new Node {
				x = 5,
				y = -10
			};

			Node startNodeB = new Node {
				x = 5,
				y = 10
			};

			Node endNode = new Node {
				x = 2,
				y = 0
			};

			Edge edgeA = new Edge {
				StartNode = startNodeA,
				EndNode = endNode
			};

			Edge edgeB = new Edge {
				StartNode = startNodeB,
				EndNode = endNode
			};

			Assert.AreEqual(
				-1,
				edgeA.CompareTo( edgeB )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareSameWeightEdgesDifferentEndNodeX() {
			Node endNodeA = new Node {
				x = 13,
				y = 3
			};

			Node endNodeB = new Node {
				x = -13,
				y = 3
			};

			Node startNode = new Node {
				x = 0,
				y = 15
			};

			Edge edgeA = new Edge {
				StartNode = startNode,
				EndNode = endNodeA
			};

			Edge edgeB = new Edge {
				StartNode = startNode,
				EndNode = endNodeB
			};

			Assert.AreEqual(
				1,
				edgeA.CompareTo( edgeB )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareSameWeightEdgesDifferentEndNodeY() {
			Node endNodeA = new Node {
				x = 13,
				y = -23
			};

			Node endNodeB = new Node {
				x = 13,
				y = 23
			};

			Node startNode = new Node {
				x = -18,
				y = 0
			};

			Edge edgeA = new Edge {
				StartNode = startNode,
				EndNode = endNodeA
			};

			Edge edgeB = new Edge {
				StartNode = startNode,
				EndNode = endNodeB
			};

			Assert.AreEqual(
				-1,
				edgeA.CompareTo( edgeB )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareToLargerWeightEdge() {
			Assert.AreEqual(
				-1,
				this.edgeBD.CompareTo( this.edgeAB )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void CompareToSmallerWeightEdge() {
			Assert.AreEqual(
				1,
				this.edgeAD.CompareTo( this.edgeAB )
			);
		}

		[Test]
		[Category( "CompareTo" )]
		public void SortEdges() {
			Edge[] sortedEdges = new Edge[] {
				this.edgeAB,
				this.edgeAC,
				this.edgeAD
			};
			Array.Sort( sortedEdges );

			Edge[] expectedResult = new Edge[] {
				this.edgeAC,
				this.edgeAB,
				this.edgeAD
			};

			CollectionAssert.AreEqual(
				expectedResult,
				sortedEdges
			);

		}

		[Test]
		[Category( "IEquatable" )]
		public void EqualEdges() {
			Edge sameEdgeAB = new Edge {
				StartNode = this.edgeAB.StartNode,
				EndNode = this.edgeAB.EndNode
			};

			Assert.IsTrue(
				this.edgeAB.Equals(
					sameEdgeAB
				)
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void EqualEdgesWithEqualOp() {
			Edge sameEdge = new Edge {
				StartNode = this.edgeAB.StartNode,
				EndNode = this.edgeAB.EndNode
			};
			
			Assert.IsTrue(
				this.edgeAB == sameEdge
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void EqualEdgesWithNotEqualOp() {
			Edge sameEdge = new Edge {
				StartNode = this.edgeAB.StartNode,
				EndNode = this.edgeAB.EndNode
			};

			Assert.IsFalse(
				this.edgeAB != sameEdge
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void NotEqualEdges() {
			Edge notSameEdge = new Edge {
				StartNode = this.edgeAC.StartNode,
				EndNode = this.edgeAC.EndNode
			};

			Assert.IsFalse(
				this.edgeAB.Equals(
					notSameEdge
				)
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void NotEqualEdgesWithEqualOp() {
			Edge notSameEdge = new Edge {
				StartNode = this.edgeAC.StartNode,
				EndNode = this.edgeAC.EndNode
			};

			Assert.IsFalse(
				this.edgeAB == notSameEdge
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void NotEqualEdgesWithNotEqualOp() {
			Edge notSameEdge = new Edge {
				StartNode = this.edgeAC.StartNode,
				EndNode = this.edgeAC.EndNode
			};

			Assert.IsTrue(
				this.edgeAB != notSameEdge
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToString() {
			string text = "Not an Edge.";

			Assert.IsFalse(
				this.edgeAB.Equals(
					text
				)
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToNull() {
			Edge nullEdge = null;
			
			Assert.IsFalse(
				this.edgeAB.Equals(
					nullEdge 
				)
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToNullWithEqualOp() {
			Edge nullEdge = null;

			Assert.IsFalse(
				this.edgeAB == nullEdge
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareToNullWithNotEqualOp() {
			Edge nullEdge = null;

			Assert.IsTrue(
				this.edgeAB != nullEdge
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareHashCodeOfSameNodes() {
			Edge sameEdge = new Edge {
				StartNode = this.edgeAB.StartNode,
				EndNode = this.edgeAB.EndNode
			};

			Assert.AreEqual(
				this.edgeAB.GetHashCode(),
				sameEdge.GetHashCode()
			);
		}

		[Test]
		[Category( "IEquatable" )]
		public void CompareHashCodeOfTwoDifferentNodes() {
			Edge notSameEdge = new Edge {
				StartNode = this.edgeAC.StartNode,
				EndNode = this.edgeAC.EndNode
			};

			Assert.AreNotEqual(
				this.edgeAB.GetHashCode(),
				notSameEdge.GetHashCode()
			);
		}

		[Test]
		public void EdgeToString() {
			string expectedOutput = "{ nodeA = "
				+ edgeAB.StartNode.ToString()
				+ "; nodeB = "
				+ edgeAB.EndNode.ToString()
				+ "; weight = "
				+ edgeAB.Weight
				+ " }"
			;

			Assert.AreEqual(
				expectedOutput,
				edgeAB.ToString()
			);
		}

	}
}
