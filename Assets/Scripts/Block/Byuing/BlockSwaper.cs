using UnityEngine;

public class BlockSwaper : MonoBehaviour
{
    [SerializeField] private BlockCreator _blockCreator;
    private Block _block;
    private void Awake()
    {
        _blockCreator.OnCreate += GetBlock;
    }

    private void GetBlock(Block block)
    {
        _block = block;
    }

    public void SwapBlock(BlockItem block)
    {
        _block.SetTypeOfBlock(block.BlockType);
    }

    private void OnDisable()
    {
        _blockCreator.OnCreate -= GetBlock;
    }
}
