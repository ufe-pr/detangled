//SPDX-License-Identifier: Unlicense
pragma solidity ^0.8.0;

import "hardhat/console.sol";
import "@openzeppelin/contracts/token/ERC1155/presets/ERC1155PresetMinterPauser.sol";


contract Detangled is ERC1155PresetMinterPauser {

    uint256 constant public BETA_TESTER  = 1;
    
    constructor() ERC1155PresetMinterPauser("https://google.com/detangled/tokens/{id}.json") {
        _mint(msg.sender, BETA_TESTER, 1, "");
    }
}
 